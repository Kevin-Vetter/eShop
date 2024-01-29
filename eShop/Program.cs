using DAL;
using ServiceLayer.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Razor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("PrimaryConnection");
builder.Services.AddRazorPages();
builder.Services.AddDbContext<eShopContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IRepo,Repo>();
builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    options.PageViewLocationFormats.Add("/Pages/Shared/Components/{0}" + RazorViewEngine.ViewExtension);
});
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

app.UseAuthorization();

app.MapRazorPages();

app.Run();

void ConfigureServices(IServiceCollection services)
{
    services.Configure<RazorViewEngineOptions>(options =>
    {
        options.PageViewLocationFormats.Add("/Pages/Partials/{0}" + RazorViewEngine.ViewExtension);
    });
}