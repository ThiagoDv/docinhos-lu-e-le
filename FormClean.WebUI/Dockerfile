# define a imagem base
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env

# define o diret�rio de trabalho
WORKDIR /app

# copia todos os arquivos .csproj para o diret�rio de trabalho
COPY FormClean.Domain/*.csproj ./FormClean.Domain/
COPY FormClean.Application/*.csproj ./FormClean.Application/
COPY FormClean.Infra.Data/*.csproj ./FormClean.Infra.Data/
COPY FormClean.Infra.IoC/*.csproj ./FormClean.Infra.IoC/
COPY FormClean.WEBUI/*.csproj ./FormClean.WEBUI/


# restaura as depend�ncias
RUN dotnet restore ./FormClean.Domain/FormClean.Domain.csproj
RUN dotnet restore ./FormClean.Application/FormClean.Application.csproj
RUN dotnet restore ./FormClean.Infra.Data/FormClean.Infra.Data.csproj
RUN dotnet restore ./FormClean.Infra.IoC/FormClean.Infra.IoC.csproj
RUN dotnet restore ./FormClean.WEBUI/FormClean.WEBUI.csproj

# copia o resto dos arquivos da aplica��o para o diret�rio de trabalho
COPY . ./

# compila a aplica��o
RUN dotnet publish -c Release -o out FormClean.Domain/FormClean.Domain.csproj
RUN dotnet publish -c Release -o out FormClean.Application/FormClean.Application.csproj
RUN dotnet publish -c Release -o out FormClean.Infra.Data/FormClean.Infra.Data.csproj
RUN dotnet publish -c Release -o out FormClean.Infra.IoC/FormClean.Infra.IoC.csproj
RUN dotnet publish -c Release -o out FormClean.WEBUI/FormClean.WEBUI.csproj

# define a imagem de destino
FROM mcr.microsoft.com/dotnet/aspnet:5.0

# define o diret�rio de trabalho
WORKDIR /app

# copia a sa�da da compila��o para a imagem de destino
COPY --from=build-env /app/out .

# inicia a aplica��o quando o cont�iner for iniciado
CMD ASPNETCORE_URLS=http://*:$PORT dotnet FormClean.WebUI.dll
