# --- Build stage ----------------------------------------------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Kopiera .csproj och restore
COPY OrderService.Api/OrderService.Api.csproj ./OrderService.Api/
RUN dotnet restore ./OrderService.Api/OrderService.Api.csproj

# Kopiera koden och publicera
COPY . .
WORKDIR /src/OrderService.Api
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# --- Runtime stage --------------------------------------------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish ./

# Connection string (kan också anges via `docker run -e`)
ENV ConnectionStrings__Default="Server=host.docker.internal,1433;Database=OrderDb;User Id=sa;Password=Your_password123!"

EXPOSE 8080
ENTRYPOINT ["dotnet", "OrderService.Api.dll"]