FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/Notifications.Api/Notifications.Api.csproj", "Notifications.Api/"]
RUN dotnet restore "Notifications.Api/Notifications.Api.csproj"

WORKDIR /src
COPY src/ .

RUN dotnet build "Notifications.Api/Notifications.Api.csproj" -o /app/build

FROM build AS publish
RUN dotnet publish "Notifications.Api/Notifications.Api.csproj"  -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Notifications.Api.dll"]
