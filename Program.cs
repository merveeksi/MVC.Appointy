using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MVC.Appointy.Data;
using MVC.Appointy.Services;

var builder = WebApplication.CreateBuilder(args);

// Localization
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] {"tr", "en", "de", "it", "zh" };
    options.SetDefaultCulture("tr");
    options.AddSupportedCultures(supportedCultures);
    options.AddSupportedUICultures(supportedCultures);
});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppointyDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAppointmentService, AppointmentService>();

var app = builder.Build();

// Localization middleware
var localizationOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>()!.Value;
app.UseRequestLocalization(localizationOptions);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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