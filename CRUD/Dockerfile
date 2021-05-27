FROM mcr.microsoft.com/dotnet/sdk:5.0.203 AS build-env
WORKDIR /app
# Copiar csproj e restaurar dependencias
COPY *.csproj ./
RUN dotnet restore
 #Build da aplicação
COPY . ./
RUN dotnet publish -c Release -o dist
# Build da imagem
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/dist .
ENTRYPOINT ["dotnet", "CRUD.dll"]