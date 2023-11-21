using API.Schemas;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient(ApiSchemas.Categories,
    c => c.BaseAddress = new Uri(ApiSchemas.CategoriesUrl));
builder.Services.AddHttpClient(ApiSchemas.Schedules,
    c => c.BaseAddress = new Uri(ApiSchemas.SchedulesUrl));

builder.Services
    .AddGraphQLServer()
    .ModifyOptions(t => t.EnableTag = false)
    .AddRemoteSchema(ApiSchemas.Categories)
    .AddRemoteSchema(ApiSchemas.Schedules)
    ;

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGraphQL();

app.Run();
