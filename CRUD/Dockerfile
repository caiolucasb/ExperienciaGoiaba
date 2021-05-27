FROM mcr.microsoft.com/dotnet/core/sdk:5.0 AS build-env
WORKDIR /app
# Copiar csproj e restaurar dependencias
COPY *.csproj ./
RUN dotnet restore
RUN pwsh -Command Write-Host "CRUD: Gerando imagem Docker"
# Build da imagem
FROM mcr.microsoft.com/dotnet/core/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/dist .
ENTRYPOINT ["dotnet", "CRUD.dll"]