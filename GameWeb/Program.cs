using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
{
    opt.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    opt.LoginPath = "/admin/login";
    opt.LogoutPath = "/admin/logout";


}

);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseStatusCodePagesWithRedirects("/hata/{0}");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(name: "default", pattern: "{controller=home}/{action=Index}/{id?}");
app.MapControllers();

app.Run();