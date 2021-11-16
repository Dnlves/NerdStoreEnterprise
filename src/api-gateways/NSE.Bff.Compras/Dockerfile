FROM mcr.microsoft.com/dotnet/sdk:5.0.403-buster-slim AS build
WORKDIR /src
COPY ["./api-gateways/NSE.Bff.Compras/NSE.Bff.Compras.csproj", "api-gateways/NSE.Bff.Compras/"]
COPY ["./building-blocks/NSE.Core/NSE.Core.csproj", "building-blocks/NSE.Core/"]
COPY ["./building-blocks/NSE.MessageBus/NSE.MessageBus.csproj", "building-blocks/NSE.MessageBus/"]
COPY ["./building-blocks/NSE.WebAPI.Core/NSE.WebAPI.Core.csproj", "building-blocks/NSE.WebAPI.Core/"]
RUN dotnet restore "/src/api-gateways/NSE.Bff.Compras/NSE.Bff.Compras.csproj"
COPY . .
WORKDIR "/src/api-gateways/NSE.Bff.Compras"
RUN dotnet build "NSE.Bff.Compras.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NSE.Bff.Compras.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0.12-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NSE.Bff.Compras.dll"]