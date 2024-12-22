using System.Text.Json;
using System.Text.Json.Serialization;
using Hangfire;
using Hangfire.MemoryStorage;
using Notifications.Api.Jobs;
using Notifications.Api.Services;
using Notifications.Email;
using Notifications.Persistence;
using Notifications.Push;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddJsonOptions(o =>
{
    o.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddHostedService<DatabaseInitializer>();

builder.Services.AddHangfire(config => config.UseMemoryStorage());
builder.Services.AddHangfireServer();

builder.Services.AddScoped<INotificationsService, NotificationsService>();
builder.Services.AddScoped<NotificationsProcessor>();

builder.Services.AddPersistence();
builder.Services.AddEmailNotifications();
builder.Services.AddPushNotifications();

var app = builder.Build();

app.UseHangfireDashboard();
using var scope = app.Services.CreateScope();
var job = scope.ServiceProvider.GetRequiredService<NotificationsProcessor>();

RecurringJob.AddOrUpdate(nameof(NotificationsProcessor.ProcessAwaitingNotifications),
    () => job.ProcessAwaitingNotifications(), () => " 0/10 * * * * *");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
