using Microsoft.EntityFrameworkCore;
using Webshop.Data;
using Webshop.Services;
using Microsoft.AspNetCore.Identity;
using Webshop.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddScoped<APIHandler>();
builder.Services.AddScoped<Database>();
builder.Services.AddScoped<ProductHandler>();
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MakeUpDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MakeUpDb")));


builder.Services.AddDefaultIdentity<User>().AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<MakeUpDbContext>();

builder.Services.AddHttpClient();

var app = builder.Build();


app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{

    var database = scope.ServiceProvider
        .GetRequiredService<Database>();

    await database.Delete();
    await database.CreateAndSeedIfNotExist();
 
}

app.UseRouting();

app.MapRazorPages();

app.MapControllerRoute(name: "default", pattern: "{controller=product}/{action=index}");
app.UseAuthentication();;

app.Run();