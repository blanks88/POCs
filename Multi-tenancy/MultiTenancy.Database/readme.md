# Before start

Run form the root of the project
```shell
# Adds migrations
dotnet ef migrations add AddSchedules --project Multi-tenancy/MultiTenancy.Database/MultiTenancy.Database.csproj -- --connection-string="Server=localhost;Port=5432;Database=MultiTenancy;User Id=postgres;Password=jerico Include Error Detail=true;" --tenant=Sidearmu

# Updates database
dotnet ef database update --project Multi-tenancy/MultiTenancy.Database/MultiTenancy.Database.csproj -- --connection-string="Server=localhost;Port=5432;Database=MultiTenancy;User Id=postgres;Password=jerico Include Error Detail=true;" --tenant=Sidearmu
```