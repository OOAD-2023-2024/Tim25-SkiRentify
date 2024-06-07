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
            name: "ZahtjevCreate",
            pattern: "/Zahtjev/Create",
            defaults: new { controller = "Zahtjev", action = "Create" }
        );

app.MapControllerRoute(
            name: "ZahtjevServis",
            pattern: "/Zahtjev/CreateServis",
            defaults: new { controller = "Zahtjev", action = "CreateServisiranje" }
        );

app.MapControllerRoute(
            name: "prikaz_opreme",
            pattern: "/Zahtjev/PrikazOpreme/{zahtjevId}",
            defaults: new { controller = "Zahtjev", action = "PrikazOpreme" }
        );

app.MapControllerRoute(
    name: "formiranje_zahtjeva",
    pattern: "OdabirServisiranje",
    defaults: new { controller = "Home", action = "OdabirServisiranje" }
);

app.MapControllerRoute(
    name: "iznajmljivanje",
    pattern: "/OdabirIznajmljivanje",
    defaults: new { controller = "Home", action = "OdabirIznajmljivanje" }
);


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();


app.Run();
