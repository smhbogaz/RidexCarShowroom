using Ridex_Car_Showroom.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddScoped<IAccountService,AccountService>();

var app = builder.Build();
app.UseSession();
app.UseRouting();
app.UseStaticFiles();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseStatusCodePagesWithReExecute("/home/index");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}",
    defaults:new {controller="Home",action="index"}
    );
app.Run();
