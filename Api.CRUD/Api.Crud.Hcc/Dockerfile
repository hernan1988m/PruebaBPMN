FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build-env
WORKDIR /AppService

# Copy everything
COPY . ./

# Restore as distinct layers
#RUN dotnet restore
RUN dotnet restore AppService.sln --configfile NuGet.config

# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine
WORKDIR /AppService
COPY --from=build-env /AppService/out .
RUN apk add --no-cache tzdata && \
    cp /usr/share/zoneinfo/America/Mexico_City /etc/localtime && \
    echo "America/Mexico_City" > /etc/timezone && \
    apk del tzdata
ENTRYPOINT ["dotnet", "AppService.Api.dll"]