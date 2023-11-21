using Schedules.API.Database;
using Schedules.API.Queries;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDatabase()
    .AddGraphQLServer()
    .AddQueryType<SchedulesQuery>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGraphQL();

app.Run();

