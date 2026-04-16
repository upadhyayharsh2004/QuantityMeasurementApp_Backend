# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY . .

RUN dotnet restore UC18/QuantityMeasurementAppWebApi/QuantityMeasurementAppWebApi.csproj
RUN dotnet publish UC18/QuantityMeasurementAppWebApi/QuantityMeasurementAppWebApi.csproj -c Release -o out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/out .

ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "QuantityMeasurementAppWebApi.dll"]