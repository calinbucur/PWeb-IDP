using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using System;

var builder = WebApplication.CreateBuilder(args);
var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string dbHostname = Environment.GetEnvironmentVariable("DB_HOSTNAME") ?? "localhost";
string dbUsername = Environment.GetEnvironmentVariable("POSTGRES_USER") ?? "user";
string dbPassword = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD") ?? "password";
string dbDatabase = Environment.GetEnvironmentVariable("POSTGRES_DB") ?? "db";
builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(@$"Host={dbHostname};Username={dbUsername};Password={dbPassword};Database={dbDatabase}"));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy  =>
                      {
                          policy.AllowAnyOrigin();
                      });
});


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dataContext.Database.Migrate();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MyAllowSpecificOrigins);

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();
