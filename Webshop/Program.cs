var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.UseStaticFiles();
app.UseRouting();


app.Run();