using AspNetCoreHero.ToastNotification;
using Microsoft.AspNetCore.Identity;
using VideoPlayerLearn.Business;
using VideoPlayerLearn.DataAccess;
using VideoPlayerLearn.DataAccess.Context;
using VideoPlayerLearn.Entities;
using VideoPlayerLearn.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddSession();


builder.Services.AddIdentity<AppUser, AppRole>(opt =>
{
    opt.Password.RequireDigit = false;
    opt.Password.RequiredLength = 4;
    opt.Password.RequireUppercase = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireNonAlphanumeric = false;
})
    .AddEntityFrameworkStores<AppDbContext>()
    .AddErrorDescriber<IdentityErrorDescriber>()
    .AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.Cookie.HttpOnly = true;
    opt.Cookie.SameSite = SameSiteMode.Strict;
    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    opt.Cookie.Name = "PortalIdentity";
    opt.ExpireTimeSpan = TimeSpan.FromDays(5);
    opt.LoginPath = new PathString("/Account/Login");
    opt.AccessDeniedPath = new PathString("/Status/AccessDenied");
});

builder.Services.AddDataAccessDependencies(builder.Configuration);
builder.Services.AddBusinessDependencies();
builder.Services.AddControllersWithViews();
builder.Services.AddNotyf(config =>
{
    config.DurationInSeconds = 3;
    config.IsDismissable = true;
    config.Position = NotyfPosition.TopRight;
    config.HasRippleEffect = true;

});

builder.Services.AddScoped<TodoUpdateModel>();

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
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
