using Microsoft.EntityFrameworkCore;
using Polyclinic.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DbContext using PostgreSQL provider.
builder.Services.AddDbContext<PolyclinicContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PolyclinicConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Patients}/{action=Index}/{id?}");

app.Run();