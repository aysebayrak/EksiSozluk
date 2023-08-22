using EksiSozluk.BusinessLayer.Abstract;
using EksiSozluk.BusinessLayer.Concrete;
using EksiSozluk.DataAccessLayer.Abstract;
using EksiSozluk.DataAccessLayer.Concrete;
using EksiSozluk.DataAccessLayer.EntityFramework;
using EksiSozluk.EntityLayer.Concrete;
using EksiSozluk.PresentationLayer.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IContentDal, EfContentDal>();
builder.Services.AddScoped<IContentService, ContentManager>();
builder.Services.AddScoped<IHeadingDal, EfHeadingDal>();
builder.Services.AddScoped<IHeadingService, HeadingManager>();
builder.Services.AddScoped<IUserDal, EfUserDal>();
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddDbContext<EksiSozlukContext>();

builder.Services.AddSession();

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<EksiSozlukContext>
    ().AddErrorDescriber<CustomIdentityValidator>
    ().AddEntityFrameworkStores<EksiSozlukContext>();



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
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
