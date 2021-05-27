FROM ubuntu:latest
LABEL version="1.0" maintainer="CaioLucas"
WORKDIR /app
USER dotnet
RUN dotnet build
COPY ./CRUD/dist.
EXPOSE 5050
ENTRYPOINT [ "dotnet", "CRUD.dll" ]