using Microsoft.OpenApi.Models;
using MR.TaskTracker.Api.Middleware;
using MR.TaskTracker.Application;
using MR.TaskTracker.Identity;
using MR.TaskTracker.Infrastructure;
using MR.TaskTracker.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddControllers();

//To access current user context
builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(options =>
{
    options.AddPolicy("all", builder => builder.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MR.TaskTracker APIs", Version = "v1" });
    var filePath = Path.Combine("docs.xml");
    c.IncludeXmlComments(filePath);
});


var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("all");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
