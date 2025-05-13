# --- Build stage ----------------------------------------------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Kopiera bara .csproj först (snabbare cache)
COPY MenuService.Api/MenuService.Api.csproj ./MenuService.Api/
RUN dotnet restore ./MenuService.Api/MenuService.Api.csproj

# Kopiera resten och bygg
COPY . .
WORKDIR /src/MenuService.Api
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# --- Runtime stage --------------------------------------------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish ./

# Om du kör SQL Server i Docker, använd host.docker.internal som server
ENV ConnectionStrings__Default="Server=host.docker.internal,1433;Database=MenuDb;User Id=sa;Password=Your_password123!"

EXPOSE 8080
ENTRYPOINT ["dotnet", "MenuService.Api.dll"]