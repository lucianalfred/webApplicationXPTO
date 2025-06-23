using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Repositories;
using AutoMapper;
using Interfaces;
using Interfaces.Services;
using Interfaces.Repositories;
using Services;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddDbContext<MarcacoesOnlineDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ClinicaConnection")));


services.AddScoped<IUtilizadorRepository, UtilizadorRepository>();
services.AddScoped<IUtilizadorService, UtilizadorService>();


builder.Services.AddScoped<IActoClinicoRepository, ActoClinicoRepository>();
builder.Services.AddScoped<IProfissionalRepository, ProfissionalRepository>();
builder.Services.AddScoped<IPedidoDeMarcacaoRepository, PedidoDeMarcacaoRepository>();


builder.Services.AddScoped<IActoClinicoService, ActoClinicoService>();
builder.Services.AddScoped<IProfissionalService, ProfissionalService>();
builder.Services.AddScoped<IPedidoDeMarcacaoService, PedidoDeMarcacaoService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.Run();

