# --- Build stage ----------------------------------------------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 1) Bring in the entire service (Api, Domain, Infrastructure)
COPY MenuService/. .

# 2) Restore & publish
WORKDIR /src/MenuService.Api
RUN dotnet restore "MenuService.Api.csproj"
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# --- Runtime stage --------------------------------------------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# 3) Bring in only the published output
COPY --from=build /app/publish ./

# ENV ConnectionStrings__MenuServiceDb=Server=host.docker.internal,1433;Database=MenuServiceDb;User Id=sa;Password=Your_password123!

EXPOSE 8080
ENTRYPOINT ["dotnet", "MenuService.Api.dll"]
