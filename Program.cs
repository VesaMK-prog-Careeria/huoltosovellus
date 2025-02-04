using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using AutoHuoltoSovellus.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AutoHuoltoSovellus.Models;
using AutoHuoltoSovellus;
using AutoHuoltoSovellus.Services;

var builder = WebApplication.CreateBuilder(args);

//Lisätään SQL Server yhteys
builder.Services.AddDbContext<HuoltoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddControllers(); // Lisätään kontrollerit
builder.Services.AddHttpClient<AutoService>(client => // Lisätään http client
{
    client.BaseAddress = new Uri("https://localhost:5037"); // Lisätään base url
});
// Jos siirrytään WebAssemblyyn niin yllä oleva vaihdetaan seuraavaan:
// builder.Services.AddHttpClient<AutoService>(client =>
// {
//     client.BaseAddress = new Uri("https://localhost:5037/");
// });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5037/") }); // *! Käytetään HTTP clienttiä
builder.Services.AddScoped<AutoService>(); // Lisätään AutoService



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.MapGet("/", () => "Hello World!");
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.MapControllers(); // Lisätään kontrollerit

app.Run();
