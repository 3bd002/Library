using Library.Application.Mapper.Books;
using Library.Application.Mapper.Shelves;
using Library.Application.Services.Books;
using Library.Application.Services.Shelves;
using Library.Infrastructure.Context;
using Library.Infrastructure.Repository.Books;
using Library.Infrastructure.Repository.Shelves;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddControllersWithViews()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new List<CultureInfo>
    {
        new CultureInfo("en"),
        new CultureInfo("ar")
    };

    options.DefaultRequestCulture = new RequestCulture("en");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

builder.Services.AddDbContext<DBLibraryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBLibraryContext")));

builder.Services.AddScoped<IShelfService, ShelfService>();
builder.Services.AddScoped<IShelfMapper, ShelfMapper>();
builder.Services.AddScoped<IShelfRepository, ShelfRepository>();

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookMapper, BookMapper>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

var localizationOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value;
app.UseRequestLocalization(localizationOptions);

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
