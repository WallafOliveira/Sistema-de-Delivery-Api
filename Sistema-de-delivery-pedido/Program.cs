using DataApplications.Data;
using Microsoft.EntityFrameworkCore;
using Sistema_de_delivery_pedido.Application.UseCases.Pedidos;
using Sistema_de_delivery_pedido.Domain.Interfaces;
using Sistema_de_delivery_pedido.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MySqlConnection");

// Banco de dados centralizado no DataApplications
builder.Services.AddDbContext<DeliveryDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Repository Registration
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();

// Use Cases Registration - Pedido
builder.Services.AddScoped<CreatePedidoUseCase>();
builder.Services.AddScoped<AtualizarStatusPedidoUseCase>();
builder.Services.AddScoped<ListarPedidosUseCase>();
builder.Services.AddScoped<ListarPedidosPorClienteUseCase>();
builder.Services.AddScoped<BuscarPedidoPorIdUseCase>();
builder.Services.AddScoped<CancelarPedidoUseCase>();

builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Sistema de Delivery - Pedido", Version = "v1" });
});

var app = builder.Build();

// Inicializa o banco de dados
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DeliveryDbContext>();
    InitializeContext.Initialize(context);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pedido v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
