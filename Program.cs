using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;
using MoviesApp.Services;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure base path for JSON file
string contentRoot = builder.Environment.ContentRootPath;
string jsonPath = Path.Combine(contentRoot, "movies_seed.json");
builder.Services.AddScoped<MovieImportService>();
builder.Services.Configure<MovieImportOptions>(options => 
{
    options.JsonFilePath = jsonPath;
});

// Add DbContext with SQLite
builder.Services.AddDbContext<MovieDbContext>(options =>
    options.UseSqlite("Data Source=movies11829.db"));

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
