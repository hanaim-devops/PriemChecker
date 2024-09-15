FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ConsolePrimeTester/ConsolePrimeTester.csproj", "ConsolePrimeTester/"]
RUN dotnet restore "ConsolePrimeTester/ConsolePrimeTester.csproj"
COPY . .
WORKDIR "/src/ConsolePrimeTester"
RUN dotnet build "ConsolePrimeTester.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ConsolePrimeTester.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConsolePrimeTester.dll"]
