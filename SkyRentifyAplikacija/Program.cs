using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SkyRentifyAplikacija.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
    name: "Zahtjev",
    pattern: "Zahtjev/{controller=Zahtjev}/{action=Create}/{id?}");

app.MapControllerRoute(
            name: "prikaz_opreme",
            pattern: "/Oprema/PrikazOpreme",
            defaults: new { controller = "Oprema", action = "PrikazOpreme" }
        );

app.MapControllerRoute(
    name: "formiranje_zahtjeva",
    pattern: "/Iznajmljivanje/FormiranjeZahtjeva",
    defaults: new { controller = "Iznajmljivanje", action = "FormiranjeZahtjeva" }
);

app.MapControllerRoute(
    name: "Iznajmljivanje",
    pattern: "Iznajmljivanje/{controller=Iznajmljivanje}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
