FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["SchemaStitching/Schedules.API/Schedules.API.csproj", "SchemaStitching/Schedules.API/"]
RUN dotnet restore "SchemaStitching/Schedules.API/Schedules.API.csproj"
COPY . .
WORKDIR "/src/SchemaStitching/Schedules.API"
RUN dotnet build "Schedules.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Schedules.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Schedules.API.dll"]
