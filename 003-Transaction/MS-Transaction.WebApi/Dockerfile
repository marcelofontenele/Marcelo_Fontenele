#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["001-Authentication/MS-Transaction.WebApi/MS-Transaction.WebApi.csproj", "001-Authentication/MS-Transaction.WebApi/"]
COPY ["001-Authentication/MS-Transaction.Infrastructure.IoC/MS-Transaction.Infrastructure.IoC.csproj", "001-Authentication/MS-Transaction.Infrastructure.IoC/"]
COPY ["001-Authentication/MS-Transaction.Application/MS-Transaction.Application.csproj", "001-Authentication/MS-Transaction.Application/"]
COPY ["001-Authentication/MS-Transaction.Domain/MS-Transaction.Domain.csproj", "001-Authentication/MS-Transaction.Domain/"]
COPY ["001-Authentication/MS-Transaction.Infra.Data/MS-Transaction.Infra.Data.csproj", "001-Authentication/MS-Transaction.Infra.Data/"]
RUN dotnet restore "001-Authentication/MS-Transaction.WebApi/MS-Transaction.WebApi.csproj"
COPY . .
WORKDIR "/src/001-Authentication/MS-Transaction.WebApi"
RUN dotnet build "MS-Transaction.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MS-Transaction.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MS-Transaction.WebApi.dll"]
