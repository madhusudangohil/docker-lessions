FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["areaCalculator/areaCalculator.csproj", "areaCalculator/"]
RUN dotnet restore "areaCalculator/areaCalculator.csproj"
COPY . .
WORKDIR "/src/areaCalculator"
RUN dotnet build "areaCalculator.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "areaCalculator.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "areaCalculator.dll"]