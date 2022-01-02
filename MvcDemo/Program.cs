using Microsoft.AspNetCore.Identity;
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

builder.Services
    .AddIdentity<ApplicationUser, IdentityRole>(options =>
    {
        options.Password.RequiredLength = 10;
        options.Password.RequiredUniqueChars = 0;
    })
    .AddEntityFrameworkStores<StudentContext>();


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
