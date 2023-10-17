using Microsoft.EntityFrameworkCore;
using MoviesApi;
using MoviesApi.Abstraction;
using MoviesApi.Db;
using MoviesApi.Repositories;
using MoviesApi.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(c =>c.UseSqlServer(builder.Configuration["AppDbContextConnection"]), ServiceLifetime.Scoped);
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddTransient<ValidateRequests>();
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
