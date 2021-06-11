#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["001-Authentication/MS-Auth.WebApi/MS-Auth.WebApi.csproj", "001-Authentication/MS-Auth.WebApi/"]
COPY ["001-Authentication/MS-Auth.Infrastructure.IoC/MS-Auth.Infrastructure.IoC.csproj", "001-Authentication/MS-Auth.Infrastructure.IoC/"]
COPY ["001-Authentication/MS-Auth.Application/MS-Auth.Application.csproj", "001-Authentication/MS-Auth.Application/"]
COPY ["001-Authentication/MS-Auth.Domain/MS-Auth.Domain.csproj", "001-Authentication/MS-Auth.Domain/"]
COPY ["001-Authentication/MS-Auth.Infra.Data/MS-Auth.Infra.Data.csproj", "001-Authentication/MS-Auth.Infra.Data/"]
COPY ["SharedLibrary/SharedLibrary/SharedLibrary.csproj", "SharedLibrary/SharedLibrary/"]
RUN dotnet restore "001-Authentication/MS-Auth.WebApi/MS-Auth.WebApi.csproj"
COPY . .
WORKDIR "/src/001-Authentication/MS-Auth.WebApi"
RUN dotnet build "MS-Auth.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MS-Auth.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MS-Auth.WebApi.dll"]