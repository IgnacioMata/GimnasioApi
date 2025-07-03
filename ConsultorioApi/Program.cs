using ConsultorioApi.Data; // 👈 Agregá esto para que reconozca ApplicationDbContext
using Microsoft.EntityFrameworkCore; // 👈 Importante para UseSqlServer

var builder = WebApplication.CreateBuilder(args);

// 💾 Inyectá ApplicationDbContext y pasá la cadena de conexión
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.Run();
