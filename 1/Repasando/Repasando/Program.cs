using Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//El AlumRepositorio de Repasando va a relacionar con el IAlumRepositorio de Services
//builder.Services.AddSingleton<IAlumRepositorio, AlumRepositorio>();
builder.Services.AddTransient<IAlumRepositorio, AlumnoRepositorioBD>();



//creamos este objeto para poder llamar en el futuro al connecttion string
IConfiguration configuration = new ConfigurationBuilder()
	.AddJsonFile("appsettings.json")
	.AddEnvironmentVariables()
	.Build();

builder.Services.AddDbContextPool<AlumnoDdContext>(options => options.UseSqlServer(configuration.GetConnectionString("ColegioDbConnection")));



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
