using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args); //Create instance of web application builder
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<eTicketsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

builder.Services.AddScoped<DBInitializer>();
builder.Services.AddScoped<IActorsService, ActorsService>();

var app = builder.Build(); //Build instance of web application

// Add services to the container.





// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseItToSeedSqlServer();    //custom extension method to seed the DB
    //configure other services
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Actor}/{action=Index}/{id?}");

app.Run();


//seed Database


