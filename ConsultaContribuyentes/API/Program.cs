using Aplicacion.Interfaces.IComprobantes;
using Aplicacion.Interfaces.IContribuyentes;
using Aplicacion.Servicios;
using Infraestructura.Persistencia.Contexto;
using Infraestructura.Persistencia.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlServer<SolucionFiscalContext>(builder.Configuration.GetConnectionString("AppConnection"));

builder.Services.AddScoped<IContribuyenteServicio,ContribuyenteServicio>();
builder.Services.AddScoped<IContribuyenteRepositorio,ContribuyenteRepositorio>();

builder.Services.AddScoped<IComprobanteRepositorio, ComprobanteRepositorio>();
builder.Services.AddScoped<IComprobanteServicio, ComprobanteServicio>();

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
