using riode.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using riode.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<RiodeDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
	options.User.RequireUniqueEmail = true;

	options.Password.RequiredLength = 8;
	options.Password.RequireUppercase = true;
	options.Password.RequireLowercase = true;
	options.Password.RequireDigit = true;
	options.Password.RequireNonAlphanumeric = true;

	options.Lockout.MaxFailedAccessAttempts = 5;
	options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
	options.Lockout.AllowedForNewUsers = true;
}).AddEntityFrameworkStores<RiodeDbContext>().AddDefaultTokenProviders();


var app = builder.Build();

app.UseStaticFiles();
app.MapControllerRoute(
	name: "areas",
	pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
	);
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=home}/{action=Index}/{id?}"

	);

app.UseAuthentication();
app.UseAuthorization();

app.Run();

