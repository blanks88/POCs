using MultiTenancy.App.Resolvers;
using MultiTenancy.Database;
using MultiTenancyAPI.Queries;

var builder = WebApplication.CreateBuilder(args);

// a must to gather request info
builder.Services.AddHttpContextAccessor();

// enables multi-tenancy
builder.Services
    .AddHttpTenantResolver()
    .AddDatabase();

// GraphQL
builder.Services
    .AddGraphQLServer()
    .AddQueryType<SchedulesQuery>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGraphQL();

app.Run();
