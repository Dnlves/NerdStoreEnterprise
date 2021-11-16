FROM mcr.microsoft.com/dotnet/sdk:5.0.403-buster-slim AS build
WORKDIR /src
COPY ["./services/NSE.Identidade.API/NSE.Identidade.API.csproj", "services/NSE.Identidade.API/"]
COPY ["./building-blocks/NSE.Core/NSE.Core.csproj", "building-blocks/NSE.Core/"]
COPY ["./building-blocks/NSE.MessageBus/NSE.MessageBus.csproj", "building-blocks/NSE.MessageBus/"]
COPY ["./building-blocks/NSE.WebAPI.Core/NSE.WebAPI.Core.csproj", "building-blocks/NSE.WebAPI.Core/"]
RUN dotnet restore "/src/services/NSE.Identidade.API/NSE.Identidade.API.csproj"
COPY . .
WORKDIR "/src/services/NSE.Identidade.API"
RUN dotnet build "NSE.Identidade.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NSE.Identidade.API.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0.12-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NSE.Identidade.API.dll"]