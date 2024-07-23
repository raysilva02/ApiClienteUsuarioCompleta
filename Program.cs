using ApiClienteUsuarioCompleta.Data;
using ApiClienteUsuarioCompleta.Helpers;
using ApiClienteUsuarioCompleta.Repository;
using ApiClienteUsuarioCompleta.Repository.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adicionar servi�os ao cont�iner
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();

// Registrar o SqlConnection como um servi�o
builder.Services.AddScoped<SqlConnection>(_ => new SqlConnection(connectionString));

builder.Services.AddAutoMapper(typeof(ClienteProfile), typeof(UsuarioProfile));

builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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