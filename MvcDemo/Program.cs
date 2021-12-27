/* Configuration Service */
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


/* Inject */
var app = builder.Build();

IConfiguration configuration = app.Configuration;


/* Configure */
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
