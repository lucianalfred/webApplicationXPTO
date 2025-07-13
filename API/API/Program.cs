using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DAL;
using DAL.Repositories;
using Services;
using Interfaces.Repositories;
using Interfaces.Services;
using Model;
using Shared;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(UtilizadorProfile)); 

builder.Services
    .AddScoped<IEmailRepository,       EmailRepository>()
    .AddScoped<IUtilizadorRepository,  UtilizadorRepository>()
    .AddScoped<IUtilizadorService,     UtilizadorService>()
    .AddScoped<IUtenteRegistadoRepository,  UtenteRegistadoRepository>()
    .AddScoped<IUtenteRegistadoService,  UtenteRegistadoService>()
    .AddScoped<IActoClinicoRepository, ActoClinicoRepository>()
    .AddScoped<IActoClinicoService,    ActoClinicoService>()
    .AddScoped<IProfissionalRepository, ProfissionalRepository>()
    .AddScoped<IProfissionalService,    ProfissionalService>()
    .AddScoped<IPedidoDeMarcacaoRepository, PedidoDeMarcacaoRepository>()
    .AddScoped<IPedidoDeMarcacaoService,    PedidoDeMarcacaoService>();


builder.Services.AddDbContext<MarcacoesOnlineDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("ClinicaConnection")));


builder.Services
    .AddIdentityCore<Utilizador>(opt =>
    {
        opt.Password.RequireDigit = false;
        opt.Password.RequireLowercase = false;
        opt.Password.RequireUppercase = false;
        opt.Password.RequireNonAlphanumeric = false;
        opt.Password.RequiredLength = 6;
    })
    .AddRoles<ApplicationRole>()
    .AddEntityFrameworkStores<MarcacoesOnlineDbContext>()
    .AddSignInManager()     
    .AddDefaultTokenProviders();


var secretKey = builder.Configuration["JwtSettings:SecretKey"]!;
var key       = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddCookie(IdentityConstants.ApplicationScheme)
    .AddJwtBearer(opt =>{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer           = false,
        ValidateAudience         = false,
        ValidateLifetime         = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey         = key
    };

    opt.Events = new JwtBearerEvents
    {
        OnChallenge = ctx =>
        {
            ctx.HandleResponse();
            ctx.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Task.CompletedTask;
        }
    };
});
builder.Services.AddAuthorization();


builder.Services.AddCors(p =>
    p.AddPolicy("Dev", policy => policy
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseCors("Dev");          
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();


using (var scope = app.Services.CreateScope())
{
    var rm = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
    foreach (var role in new[] { "Administrador", "Administrativo", "Utente" })
        if (!await rm.RoleExistsAsync(role))
            await rm.CreateAsync(new ApplicationRole { Name = role });
}

app.Run();
