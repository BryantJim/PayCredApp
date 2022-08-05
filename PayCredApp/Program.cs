using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using PayCredApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using PayCredApp.BLL;
using PayCredApp.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.Toast;

var builder = WebApplication.CreateBuilder(args);

// Añadiendo los servicios de la base de datos
builder.Services.AddDbContext<Contexto>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnDb")), ServiceLifetime.Scoped);

// Add services to the container.
builder.Services.AddAuthenticationCore();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<ProtectedLocalStorage>();
builder.Services.AddBlazoredToast();
//Añadiendo BLL
builder.Services.AddTransient<UsuarioBLL>();
builder.Services.AddTransient<ClienteBLL>();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
