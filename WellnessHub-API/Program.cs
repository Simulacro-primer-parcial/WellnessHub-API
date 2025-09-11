using Microsoft.EntityFrameworkCore;
using WellnessHub_API; // Asegurate de que este sea el namespace correcto

var builder = WebApplication.CreateBuilder(args);

// 1. Configurar el DbContext con la cadena de conexión
builder.Services.AddDbContext<WellnessHubContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Servicios del controlador + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 3. Middleware de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 4. Middleware general
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();