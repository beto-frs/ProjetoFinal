using Destino_Certo.Crypto;
using Destino_Certo.Data;
using Destino_Certo.Models.ADONET;
using Destino_Certo.SendEmail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var ConnectionStrings = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<Context>(opts =>
{
   opts
    .UseLazyLoadingProxies().UseSqlServer(ConnectionStrings);
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ISendEmail,SendEmail>();
builder.Services.AddScoped<ICrypto, Crypto>();
builder.Services.AddScoped<IAuth, Auth>();



builder
    .Services.Configure<CookiePolicyOptions>(options =>
    {
    options.CheckConsentNeeded = context => false;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
builder.Services.AddMemoryCache();
builder.Services.AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(30));
builder.Services.AddControllersWithViews();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseCookiePolicy();

app.UseSession();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
