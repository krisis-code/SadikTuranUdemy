using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IPostRepository,EfPostRepository>();
builder.Services.AddScoped<ITagRepository, EfTagRepository>();

builder.Services.AddDbContext<BlogContext>(options => {

    var config = builder.Configuration;

    //var connectionString = config.GetConnectionString("sql_connection");
    var connectionString = config.GetConnectionString("SqlServer_Connection");

    //options.UseSqlite(connectionString);

    options.UseSqlServer(connectionString);


});

var app = builder.Build();

SeedData.TestDataFill(app);

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
    name: "posts_details",
    pattern: "posts/details/{url}",
    defaults: new {controller = "Posts" , action = "Details"  });

app.MapControllerRoute(
    name: "posts_bu_tag",
    pattern: "posts/tag/{tag}",
    defaults: new { controller = "Posts", action = "Index" });


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
