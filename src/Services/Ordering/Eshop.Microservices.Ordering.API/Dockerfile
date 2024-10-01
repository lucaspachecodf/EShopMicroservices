# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Ordering/Eshop.Microservices.Ordering.API/Eshop.Microservices.Ordering.API.csproj", "Services/Ordering/Eshop.Microservices.Ordering.API/"]
COPY ["BuildingBlocks/Eshop.Microservices.BuildingBlocks/Eshop.Microservices.BuildingBlocks.csproj", "BuildingBlocks/Eshop.Microservices.BuildingBlocks/"]
COPY ["Services/Ordering/Eshop.Microservices.Ordering.Application/Eshop.Microservices.Ordering.Application.csproj", "Services/Ordering/Eshop.Microservices.Ordering.Application/"]
COPY ["BuildingBlocks/Eshop.Microservices.BuildingBlocks.Messaging/Eshop.Microservices.BuildingBlocks.Messaging.csproj", "BuildingBlocks/Eshop.Microservices.BuildingBlocks.Messaging/"]
COPY ["Services/Ordering/Eshop.Microservices.Ordering.Domain/Eshop.Microservices.Ordering.Domain.csproj", "Services/Ordering/Eshop.Microservices.Ordering.Domain/"]
COPY ["Services/Ordering/Eshop.Microservices.Ordering.Infrastructure/Eshop.Microservices.Ordering.Infrastructure.csproj", "Services/Ordering/Eshop.Microservices.Ordering.Infrastructure/"]
RUN dotnet restore "./Services/Ordering/Eshop.Microservices.Ordering.API/Eshop.Microservices.Ordering.API.csproj"
COPY . .
WORKDIR "/src/Services/Ordering/Eshop.Microservices.Ordering.API"
RUN dotnet build "./Eshop.Microservices.Ordering.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Eshop.Microservices.Ordering.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Eshop.Microservices.Ordering.API.dll"]