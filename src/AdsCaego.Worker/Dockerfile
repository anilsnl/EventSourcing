FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/AdsCaego.Worker/AdsCaego.Worker.csproj", "AdsCaego.Worker/"]
RUN dotnet restore "src/AdsCaego.Worker/AdsCaego.Worker.csproj"
COPY . .
WORKDIR "/src/AdsCaego.Worker"
RUN dotnet build "AdsCaego.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AdsCaego.Worker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdsCaego.Worker.dll"]
