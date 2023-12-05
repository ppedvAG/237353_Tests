using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using ppedv.CubicleCarnival.Logic;
using ppedv.CubicleCarnival.Model.Contracts;
using ppedv.CubicleCarnival.UI.Web.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

string conString = "Server=(localdb)\\mssqllocaldb;Database=CubicleCarnival_dev;Trusted_Connection=true;";
builder.Services.AddScoped<IRepository>(x => new ppedv.CubicleCarnival.Data.EfCore.EfRepository(conString));
builder.Services.AddScoped<PersonenService>();

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
