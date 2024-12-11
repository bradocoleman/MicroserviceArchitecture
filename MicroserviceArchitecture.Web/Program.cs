using MicroserviceArchitecture.Web.Service;
using MicroserviceArchitecture.Web.Service.IService;
using MicroserviceArchitecture.Web.Utility;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using static MicroserviceArchitecture.Web.Utility.SD;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//configure httpClient for DI;
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<ITokenProvider, TokenProvider>();
builder.Services.AddHttpClient<IEntityService, EntityService>();
builder.Services.AddHttpClient<IAuthService, AuthService>();



//assign Entity and Auth API
SD.EntityAPIBase = builder.Configuration["ServiceUrls:EntityAPI"];
SD.AuthAPIBase = builder.Configuration["ServiceUrls:AuthAPI"];

//register/configure BaseService  EntityService  AuthService and define Scoped lifetime
builder.Services.AddScoped<ITokenProvider, TokenProvider>();
builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<IEntityService, EntityService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromHours(10);
        options.LoginPath = "/Auth/Login";
        options.AccessDeniedPath = "/Auth/AccessDenied";
    });


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
