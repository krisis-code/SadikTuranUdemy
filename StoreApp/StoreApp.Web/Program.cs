using Microsoft.EntityFrameworkCore;
using StoreApp.data.Abstract;
using StoreApp.data.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StoreDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"],b => b.MigrationsAssembly("StoreApp.web"));
} );

builder.Services.AddScoped<IStoreRepository,EFStoreRepository>();

var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();
