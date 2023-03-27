using lesohem_ASP_NET_MVC.DataBase;
using lesohem_ASP_NET_MVC.IService;
using lesohem_ASP_NET_MVC.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(op =>
{
    op.AccessDeniedPath = "/Home/Index";
});
builder.Services.AddAuthorization();
builder.Services.AddDbContext<lesohemContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnetction")));
builder.Services.AddTransient<ISocMedia, SocMedia>();
builder.Services.AddScoped<IInfoProfile, InfoProfile>();
builder.Services.AddScoped<IFiles,Files>();
builder.Services.AddMemoryCache();

var app = builder.Build();
app.UseRouting();
app.UseStaticFiles();
app.UseDefaultFiles();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
            name : "MyArea",
            pattern : "{area:exists}/{controller=Profile}/{action=Profile}/{id?}"
        );
    endpoints.MapControllerRoute(
            name : "default",
            pattern : "{controller=Home}/{action=Index}/{id?}"
        );
});

app.Run();

public partial class Test
{
    public int Id { get; set; }
    public string? Mname { get; set; }
    public string? Link { get; set; }
    public int? PersonId { get; set; }
}