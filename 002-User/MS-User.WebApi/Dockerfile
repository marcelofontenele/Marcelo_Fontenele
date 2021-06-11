#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["001-Authentication/MS-User.WebApi/MS-User.WebApi.csproj", "001-Authentication/MS-User.WebApi/"]
COPY ["001-Authentication/MS-User.Infrastructure.IoC/MS-User.Infrastructure.IoC.csproj", "001-Authentication/MS-User.Infrastructure.IoC/"]
COPY ["001-Authentication/MS-User.Application/MS-User.Application.csproj", "001-Authentication/MS-User.Application/"]
COPY ["001-Authentication/MS-User.Domain/MS-User.Domain.csproj", "001-Authentication/MS-User.Domain/"]
COPY ["001-Authentication/MS-User.Infra.Data/MS-User.Infra.Data.csproj", "001-Authentication/MS-User.Infra.Data/"]
RUN dotnet restore "001-Authentication/MS-User.WebApi/MS-User.WebApi.csproj"
COPY . .
WORKDIR "/src/001-Authentication/MS-User.WebApi"
RUN dotnet build "MS-User.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MS-User.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MS-User.WebApi.dll"]
