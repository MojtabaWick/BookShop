using BookShop.Domain.BookAgg.Contracts;
using BookShop.Domain.CategoryAgg.Contracts;
using BookShop.Domain.FileAgg.Contracts;
using BookShop.Infrastructure.EFCore.Persistence;
using BookShop.Infrastructure.EFCore.Repositories.BookAgg;
using BookShop.Infrastructure.EFCore.Repositories.CategoryAgg;
using BookShop.Services.BookAgg;
using BookShop.Services.CategoryAgg;
using BookShop.Services.FileAgg;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=BookShop;Trusted_Connection=True;"));

builder.Services.AddScoped<IBookRepository , BookRepository>();
builder.Services.AddScoped<IBookService , BookService>();
builder.Services.AddScoped<ICategoryRepository , CategoryRepository>();
builder.Services.AddScoped<ICategoryService , CategoryService>();
builder.Services.AddScoped<IFileService , FileService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
