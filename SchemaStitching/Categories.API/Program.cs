using Categories.API.Database;
using Categories.API.Queries;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDatabase()
    .AddGraphQLServer()
    .ModifyOptions(t => t.EnableTag = false)
    .AddQueryType<CategoriesQuery>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGraphQL();

app.Run();
