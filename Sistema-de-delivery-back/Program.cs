using DataApplications.Data;
using Microsoft.EntityFrameworkCore;
using Sistema_de_delivery_back.Application.UseCases;
using Sistema_de_delivery_back.Application.UseCases.Usuarios;
using Sistema_de_delivery_back.Domain.Repositories;
using Sistema_de_delivery_back.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MySqlConnection");

// Banco de dados centralizado no DataApplications
builder.Services.AddDbContext<DeliveryDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Repository Registration
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// Use Cases Registration - Usuario
builder.Services.AddScoped<CreateUsuarioUseCase>();
builder.Services.AddScoped<UpdateUsuarioUseCase>();
builder.Services.AddScoped<ListarUsuariosUseCase>();
builder.Services.AddScoped<BuscarUsuarioPorIdUseCase>();
builder.Services.AddScoped<LoginUsuarioUseCase>();

// CORS Configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Sistema de Delivery - Back", Version = "v1" });
});

var app = builder.Build();

app.UseCors("AllowAll");

// Inicializa o banco de dados
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DeliveryDbContext>();
    InitializeContext.Initialize(context);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Back v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();