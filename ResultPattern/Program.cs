using ResultPattern.Endpoints;
using ResultPattern.Endpoints.User;
using ResultPattern.Users;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<IUserRepository, UserRepository>();

builder.Services.AddEndpoints(typeof(Program).Assembly);

// For controllers
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapEndpoints();

// For controllers
app.MapControllers();

app.Run();