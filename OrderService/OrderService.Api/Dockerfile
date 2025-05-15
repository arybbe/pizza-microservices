# --- Build stage ----------------------------------------------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 1) Copy the entire OrderService folder (Api, Domain, Infrastructure)
COPY OrderService/. .

# 2) Restore & publish the API project
WORKDIR /src/OrderService.Api
RUN dotnet restore "OrderService.Api.csproj"
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# --- Runtime stage --------------------------------------------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# 3) Copy over published output
COPY --from=build /app/publish ./

ENV ConnectionStrings__OrderServiceDb="Server=host.docker.internal,1433;Database=OrderServiceDb;User Id=sa;Password=Your_password123!"
EXPOSE 8080
ENTRYPOINT ["dotnet", "OrderService.Api.dll"]
