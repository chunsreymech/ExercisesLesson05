using Microsoft.EntityFrameworkCore;
using ExercisesLesson05.Data;

var builder = WebApplication.CreateBuilder(args);

// [ចំណុចទី ១]. ចាប់យក Connection និងចុះឈ្មោះចូល DI Container
var conn = builder.Configuration.GetConnectionString("StoreConnection");
builder.Services.AddDbContext<StoreDbContext>(opt => opt.UseSqlServer(conn));

// [ចំណុចទី ២]. ដោះស្រាយបញ្ហា CORS (អនុញ្ញាតឱ្យ Frontend ហៅ API ចូលបាន)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddControllers();
var app = builder.Build();

// [ចំណុចទី ៣]. បើកដំណើរការ CORS Policy ដែលទើបកំណត់ខាងលើ
app.UseCors("AllowAll");

app.MapControllers();
app.Run();