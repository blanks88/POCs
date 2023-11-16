using MultiTenancy.App.Resolvers;
using MultiTenancy.Database;
using MultiTenancyAPI.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGraphQL();

app.Run();
