# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /Source

# copy csproj and restore as distinct layers
COPY Source/ .
RUN dotnet restore -r linux-x64

# copy everything else and build app
COPY Source/ ./Source/
WORKDIR /Source/Clarivi.Analysys.API
RUN dotnet publish -c release -o /app -r linux-x64 --self-contained false --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-bionic
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["./Clarivi.Analysys.API"]