# 1. Build için .NET 9.0 SDK
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

COPY *.sln .
COPY WebApi/*.csproj ./WebApi/
COPY Business/*.csproj ./Business/
COPY DataAccess/*.csproj ./DataAccess/
COPY Entities/*.csproj ./Entities/

RUN dotnet restore
COPY . .
RUN dotnet publish WebApi/WebApi.csproj -c Release -o /out

# 2. Run için .NET 9.0 runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

# MSSQL bağlantısı için eksik kütüphane kuruluyor
RUN apt-get update && apt-get install -y libgssapi-krb5-2

COPY --from=build /out .

ENTRYPOINT ["dotnet", "WebApi.dll"]
