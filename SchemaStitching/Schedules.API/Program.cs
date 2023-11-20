var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer();


var app = builder.Build();

app.UseHttpsRedirection();

app.MapGraphQL();

app.Run();

