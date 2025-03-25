using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;
using UnitOfWorkAPI.DataAccess.Context;
using UnitOfWorkAPI.DataAccess.Implementation;
using UnitOfWorkAPI.Domain.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<UowDbContext>(options => options.UseSqlServer(builder.Configuration["ConnectionString"]));

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>(); // UnitOfWork'ü servis olarak ekleyin
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "UnitOfWorkAPI",
        Version = "v1",
        Description = "EFCore and UnitOfWork With .NET Core 9 API"
    });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/openapi/v1.json", "UnitOfWorkAPI");
        c.RoutePrefix = string.Empty; // Swagger'ý root path'te açmak için
    });
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
