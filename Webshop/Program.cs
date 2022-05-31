using Microsoft.EntityFrameworkCore;
using Webshop.Data;
using Webshop.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<APIHandler>();
builder.Services.AddScoped<Database>();
builder.Services.AddScoped<ProductHandler>();

builder.Services.AddDbContext<MakeUpDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MakeUpDb")));

builder.Services.AddHttpClient();

var app = builder.Build();


app.UseStaticFiles();
app.UseRouting();

using (var scope = app.Services.CreateScope())
{

    var database = scope.ServiceProvider
        .GetRequiredService<Database>();

    await database.CreateAndSeedIfNotExist();

}

app.UseRouting();

app.MapControllerRoute(name: "default", pattern: "{controller=product}/{action=index}");

app.Run();