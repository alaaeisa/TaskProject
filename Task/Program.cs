using Microsoft.Extensions.DependencyInjection;
using TaskProject;
using TaskProject.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddTransientServices();
builder.Services.AddDBContext(builder.Configuration);
builder.Services.AddCor();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
   
    endpoints.MapAreaControllerRoute(
    name: "CPArea",
    areaName: "cp",
    pattern: "cp/{controller=Account}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "cp/{controller=Home}/{action=Index}/{id?}");

 

});

app.UseAuthorization();

app.MapRazorPages();

app.Run();
