using Microsoft.EntityFrameworkCore;
using Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddTransient<IEquipoRepositorio, EquipoRepositorio>();

//creamos este objeto para poder llamar en el futuro al connecttion string
IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

//metemos la base de datos al builder nuget EntityFrameworkCore.SqlServer
builder.Services.AddDbContextPool<FutbolDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("FutbolDbConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

