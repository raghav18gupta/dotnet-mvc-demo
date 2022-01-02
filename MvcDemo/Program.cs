using Microsoft.EntityFrameworkCore;
using MvcDemo.Models;


var builder = WebApplication.CreateBuilder(args);


/* Inject */
IConfiguration configuration = builder.Configuration;


/* Configuration Service */
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StudentContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DemoConnectionString"));
});


/* Configure */
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=StudentList}/{id?}");

app.Run();
