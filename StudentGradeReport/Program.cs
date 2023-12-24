using Microsoft.EntityFrameworkCore;
using StudentGradeReport.Data;
using System.Diagnostics.Metrics;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;


// Add services to the container.

var services = builder.Services;

services.AddControllers();
services.AddDbContext<StudentGradeReportContext>(options =>
       options.UseSqlServer(configuration.GetConnectionString("StudentGradeportContext")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("StudentGradeReport.Application")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("allowFE", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // Specify the allowed origin
              .AllowAnyMethod() // Allow all HTTP methods
              .AllowAnyHeader(); // Allow all headers
    });
});


var app = builder.Build();


//Automatically run migrations
using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetService<StudentGradeReportContext> ();
    if(context is not null && context.Database.GetPendingMigrations().Any()){
        context.Database.Migrate();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("allowFE");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
