FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["SchemaStitching/Categories.API/Categories.API.csproj", "SchemaStitching/Categories.API/"]
RUN dotnet restore "SchemaStitching/Categories.API/Categories.API.csproj"
COPY . .
WORKDIR "/src/SchemaStitching/Categories.API"
RUN dotnet build "Categories.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Categories.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Categories.API.dll"]
