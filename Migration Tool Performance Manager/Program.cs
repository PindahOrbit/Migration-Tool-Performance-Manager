using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Migration_Tool_Performance_Manager.Areas.Identity.Data;
using Migration_Tool_Performance_Manager.Data;
using Migration_Tool_Performance_Manager.Data2;
using System;
using System.Configuration;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("migrationConn") ?? throw new InvalidOperationException("Connection string 'SqlServerContextConnection' not found.");
var serverString = builder.Configuration.GetConnectionString("serverConn") ?? throw new InvalidOperationException("Connection string 'SqlServerContextConnection' not found.");

builder.Services.AddDbContext<MigrationDbContext>(options =>
    options.UseMySql(
        connectionString,
        new MySqlServerVersion(new Version(8, 0, 40)) // Replace with your MySQL version
    ));

builder.Services.AddDbContext<ServerDbContext>(options =>
    options.UseSqlServer(
        connectionString // Replace with your MySQL version
    ));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews()
        .AddNewtonsoftJson(d => d.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
