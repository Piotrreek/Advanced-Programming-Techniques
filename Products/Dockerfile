FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/Products.Api/Products.Api.csproj", "Products.Api/"]
RUN dotnet restore "Products.Api/Products.Api.csproj"

WORKDIR "/src/"
COPY src/ .

RUN dotnet build "Products.Api/Products.Api.csproj" -o /app/build

FROM build AS publish
RUN dotnet publish "Products.Api/Products.Api.csproj"  -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Products.Api.dll"]