
using PasswordGenerator.core;
using PasswordGenerator.webapi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet("", () =>
{
    return Results.Redirect("/swagger/index.html");
});

app.MapGet("v1/passwords", (short? len, bool? specialChars, bool? uppercase)
    => Results.Ok(new PasswordResponse(Password.Generate(len ?? 16, specialChars ?? true, uppercase ?? false))))
    .Produces<string>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.Run();
