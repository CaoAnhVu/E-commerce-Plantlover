using Cs_Plantlover.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Cs_Plantlover.Repository;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add configuration
builder.Configuration.AddJsonFile("appsettings.json");

// Add DbContext configuration
builder.Services.AddDbContext<DoAnWebDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DoAnWebDb")));



// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DoAnWebDbContext");
builder.Services.AddDbContext<DoAnWebDbContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddIdentity <IdentityUser, IdentityRole> ()
.AddDefaultTokenProviders()
.AddDefaultUI()
.AddEntityFrameworkStores <DoAnWebDbContext> ();

builder.Services.AddRazorPages();
builder.Services.AddScoped<IChucNangSPRepository, ChucNangSPRepository>();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
app.UseSession();
app.MapRazorPages();
app.UseEndpoints(endpoints => {
    endpoints.MapRazorPages();
    endpoints.MapControllerRoute("default", "{area=Customer}/{controller=Home}/{action=Index}/{id?}");
});


app.Run();
