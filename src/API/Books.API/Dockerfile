# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/API/Books.API/Books.API.csproj", "src/API/Books.API/"]
COPY ["src/Application/Books.Application/Books.Application.csproj", "src/Application/Books.Application/"]
COPY ["src/Domain/Books.Domain/Books.Domain.csproj", "src/Domain/Books.Domain/"]
COPY ["src/Infrastructure/Books.Infrastructure/Books.Infrastructure.csproj", "src/Infrastructure/Books.Infrastructure/"]
RUN dotnet restore "./src/API/Books.API/Books.API.csproj"
COPY . .
WORKDIR "/src/src/API/Books.API"
RUN dotnet build "./Books.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Books.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Books.API.dll"]