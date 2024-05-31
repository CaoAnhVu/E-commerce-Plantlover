using Cs_Plantlover.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Cs_Plantlover.Repository;
using Microsoft.AspNetCore.Identity;
using Data;
using Repository.IRepository;
using Cs_Plantlover.Repository.IRepository;
using Cs_Plantlover.Models.Services;
using Cs_Plantlover.Services;

var builder = WebApplication.CreateBuilder(args);

// Add configuration
builder.Configuration.AddJsonFile("appsettings.json");

// Add DbContext configuration
builder.Services.AddDbContext<DoAnWebDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DoAnWebDb")));


var connectionString = builder.Configuration.GetConnectionString("DoAnWebDbContext");
builder.Services.AddDbContext<DoAnWebDbContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IChucNangSPRepository, ChucNangSPRepository>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<IViTriRepository, ViTriRepository>();

//add Identity
builder.Services.AddIdentity<User, IdentityRole>()
.AddDefaultTokenProviders()
.AddDefaultUI()
.AddEntityFrameworkStores<DoAnWebDbContext>();
builder.Services.AddRazorPages();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.LoginPath = $"/Identity/Account/AccessDenied";
}
);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IChucNangSPRepository, ChucNangSPRepository>();
builder.Services.AddScoped<IViTriRepository, ViTriRepository>();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

builder.Services.AddSingleton<IVnPayService, VnPayService>();
builder.Services.AddSingleton<IMomoService, MomoService>();

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
app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("default", "{area=Customer}/{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute("Admin", "{area=exists}/{controller=Home}/{action=Index}/{id?}");
    app.MapRazorPages();
});


app.Run();
