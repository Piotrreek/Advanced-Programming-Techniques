using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Products.Application.Abstractions;
using Products.Domain.Abstractions;

namespace Products.Infrastructure.Exceptions;

internal sealed class ExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (ValidationException validationException)
        {
            const int statusCode = StatusCodes.Status400BadRequest;

            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Type = "ValidationFailure",
                Title = "Validation error",
                Detail = "One or more validation errors has occurred"
            };

            if (validationException.Errors is not null)
            {
                problemDetails.Extensions["errors"] = validationException.Errors
                    .Select(err => new { err.PropertyName, err.ErrorMessage });
            }

            context.Response.StatusCode = statusCode;

            _logger.LogInformation("Validation failure occurred. Problem: {@Problem}", problemDetails);

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
        catch (NotFoundException notFoundException)
        {
            const int statusCode = StatusCodes.Status404NotFound;

            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Type = "NotFound",
                Title = "Resource was not found",
                Detail = notFoundException.Message
            };

            _logger.LogInformation("Resource was not found. Error: {Error}", notFoundException.Message);

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
        catch (ProductsException productsException)
        {
            const int statusCode = StatusCodes.Status400BadRequest;

            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Type = FormatExceptionName(productsException),
                Title = "Business logic error",
                Detail = productsException.Message
            };

            context.Response.StatusCode = statusCode;

            _logger.LogInformation("Business logic error occurred. Problem: {@Problem}", problemDetails);

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
        catch (Exception exception)
        {
            const int statusCode = StatusCodes.Status500InternalServerError;

            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = "Error",
                Detail = "There was an error."
            };

            context.Response.StatusCode = statusCode;

            _logger.LogError(exception, "There was an error. Problem: {@Problem}", exception.Message);

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }

    private static string FormatExceptionName(Exception exception) =>
        exception.GetType().Name.Replace("Exception", string.Empty);
}