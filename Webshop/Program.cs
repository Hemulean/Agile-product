var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=index}");
app.UseStaticFiles();
app.UseRouting();


app.Run();