using Microsoft.EntityFrameworkCore;
using TH01.Data;
using TH01.Models.Interfaces;
using TH01.Models.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddDbContext<CoffeeshopDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("TH01DbContextConnection")));

var app = builder.Build();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();