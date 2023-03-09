using Filmes.Data;
using Filmes.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(x => x.UseLazyLoadingProxies().UseMySQL(builder.Configuration.GetConnectionString("FilmeConnection")));
builder.Services.AddScoped<FilmeService, FilmeService>();
builder.Services.AddScoped<GerenteService, GerenteService>();
builder.Services.AddScoped<CinemaService, CinemaService>();
builder.Services.AddScoped<SessaoService, SessaoService>();
builder.Services.AddScoped<EnderecoService, EnderecoService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
