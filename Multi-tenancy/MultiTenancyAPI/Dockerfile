FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Multi-tenancy/MultiTenancyAPI/MultiTenancyAPI.csproj", "Multi-tenancy/MultiTenancyAPI/"]
RUN dotnet restore "Multi-tenancy/MultiTenancyAPI/MultiTenancyAPI.csproj"
COPY . .
WORKDIR "/src/Multi-tenancy/MultiTenancyAPI"
RUN dotnet build "MultiTenancyAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MultiTenancyAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MultiTenancyAPI.dll"]
