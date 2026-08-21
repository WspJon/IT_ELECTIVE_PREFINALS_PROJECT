using Microsoft.EntityFrameworkCore;
using IT_ELECTIVE_PREFINALS_PROJECT.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Automatic Dynamic Path Finder para sa lycevm.db
var dbPath = Path.Combine(builder.Environment.ContentRootPath, "lycevm.db");
if (!File.Exists(dbPath))
{
    var parentDb = Path.Combine(builder.Environment.ContentRootPath, "..", "lycevm.db");
    if (File.Exists(parentDb))
    {
        dbPath = parentDb;
    }
}

builder.Services.AddDbContext<HelpDeskContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();