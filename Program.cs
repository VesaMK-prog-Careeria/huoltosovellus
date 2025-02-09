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
builder.Services.AddControllers(); // Lisätään kontrollerit

//Määritetään yhteinen BASE URL
builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = new Uri("http://localhost:5037/");
});
// Jos siirrytään WebAssemblyyn niin yllä oleva vaihdetaan seuraavaan:
// builder.Services.AddHttpClient<AutoService>(client =>
// {
//     client.BaseAddress = new Uri("https://localhost:5037/");
// });

// Käytetään yleistä HTTP clienttiä eri serviceiden välillä
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ApiClient"));
builder.Services.AddScoped<AutoService>();
builder.Services.AddScoped<PerävaunuService>();
builder.Services.AddScoped<SäiliöService>();


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
app.MapControllers(); // Lisätään kontrollerit

app.Run();
