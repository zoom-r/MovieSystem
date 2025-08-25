using System.Reflection;
using MovieSystem.Domain.Interfaces;
using MovieSystem.Infrastructure.Repositories;
using MovieSystem.Application.Mapping;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using MovieSystem.Application.DTOs;
using MovieSystem.Application.Validators;
using MovieSystem.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddAutoMapper(typeof(MappingProfile));

var assembly = Assembly.GetExecutingAssembly();
builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(assembly));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IDirectorRepository, DirectorRepository>();
builder.Services.AddScoped<IRatingRepository, RatingRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieSystem API v1");
        c.RoutePrefix = "swagger"; // Swagger at /swagger
    });
}
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
