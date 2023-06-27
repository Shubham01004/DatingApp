using API.Data;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();

builder.Services.AddControllers();
builder.Services.AddDbContext<DbContext>(opt => 
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});


var app = builder.Build();

app.MapControllers();
app.UseCors(builder=>builder.AllowAnyHeader().AllowAnyHeader().WithOrigins("https://localhost:4200"));
app.Run();