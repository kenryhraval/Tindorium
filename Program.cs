using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Tindorium.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TindoriumDbContext>(); //scoped
builder.Services.AddScoped<UserRepository>();

var app = builder.Build();

app.UseCors(builder =>
        builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

// app.UseHttpsRedirection();

// Configure the HTTP request pipeline.

// app.UseRouting();

// app.UseAuthorization();

app.MapControllers();

app.Run();


