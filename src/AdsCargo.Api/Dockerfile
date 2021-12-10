FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/AdsCargo.Api/AdsCargo.Api.csproj", "AdsCargo.Api/"]
RUN dotnet restore "src/AdsCargo.Api/AdsCargo.Api.csproj"
COPY . .
WORKDIR "/src/AdsCargo.Api"
RUN dotnet build "AdsCargo.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AdsCargo.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdsCargo.Api.dll"]
