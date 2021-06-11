#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["001-Authentication/MS-Investiments.WebApi/MS-Investiments.WebApi.csproj", "001-Authentication/MS-Investiments.WebApi/"]
COPY ["001-Authentication/MS-Investiments.Infrastructure.IoC/MS-Investiments.Infrastructure.IoC.csproj", "001-Authentication/MS-Investiments.Infrastructure.IoC/"]
COPY ["001-Authentication/MS-Investiments.Application/MS-Investiments.Application.csproj", "001-Authentication/MS-Investiments.Application/"]
COPY ["001-Authentication/MS-Investiments.Domain/MS-Investiments.Domain.csproj", "001-Authentication/MS-Investiments.Domain/"]
COPY ["001-Authentication/MS-Investiments.Infra.Data/MS-Investiments.Infra.Data.csproj", "001-Authentication/MS-Investiments.Infra.Data/"]
RUN dotnet restore "001-Authentication/MS-Investiments.WebApi/MS-Investiments.WebApi.csproj"
COPY . .
WORKDIR "/src/001-Authentication/MS-Investiments.WebApi"
RUN dotnet build "MS-Investiments.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MS-Investiments.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MS-Investiments.WebApi.dll"]
