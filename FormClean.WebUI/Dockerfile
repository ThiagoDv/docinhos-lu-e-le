
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

COPY *.sln ./
COPY ./FormClean.Domain/*.csproj ./FormClean.Domain/
COPY ./FormClean.Application/*.csproj ./FormClean.Application/
COPY ./FormClean.Infra.IoC/*.csproj ./FormClean.Infra.IoC/
COPY ./FormClean.Infra.Data/*.csproj ./FormClean.Infra.Data/
COPY ./FormClean.WebUI/*.csproj ./FormClean.WebUI/
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .

# CMD ASPNETCORE_URLS="http://*:$PORT" dotnet FormClean.WebUI.dll

ENTRYPOINT [ "dotnet", "FormClean.dll" ]