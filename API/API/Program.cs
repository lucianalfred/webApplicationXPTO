using Microsoft.EntityFrameworkCore;
using DAL;
using Interfaces;
using Services;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();
app.UseRouting();
app.UseAuthorization();
app.MapControllers(); 
app.Run();

