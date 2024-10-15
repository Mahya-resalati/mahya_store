using mahya_store.Application.Interfaces.Contexts;
using mahya_store.Application.Interfaces.FacadPatterns;
using mahya_store.Application.Services.Common.Queries.GetCategory;
using mahya_store.Application.Services.Common.Queries.GetHomePageImage;
using mahya_store.Application.Services.Common.Queries.GetMenuItem;
using mahya_store.Application.Services.Common.Queries.GetSlider;
using mahya_store.Application.Services.HomePage.AddHomepageImages;
using mahya_store.Application.Services.HomePage.AddNewSlider;
using mahya_store.Application.Services.Products.FacadPattern;
using mahya_store.Application.Services.Users.Commands.EditUser;
using mahya_store.Application.Services.Users.Commands.RegisterUser;
using mahya_store.Application.Services.Users.Commands.RemoveUser;
using mahya_store.Application.Services.Users.Commands.UserLogin;
using mahya_store.Application.Services.Users.Commands.UserStatusChange;
using mahya_store.Application.Services.Users.Queries.GetRoles;
using mahya_store.Application.Services.Users.Queries.GetUsers;
using mahya_store.Persistance.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
String connectionString = "Data Source=ASUS-PC; Initial Catalog=Mahya_StoreDB; Integrated Security=True; TrustServerCertificate=True;";
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataBaseContext>(option => option.UseSqlServer(connectionString)); ;
builder.Services.AddScoped<IDataBaseContext,  DataBaseContext>();
builder.Services.AddScoped<IGetUsersService, GetUsersService>();
builder.Services.AddScoped<IGetRolesService, GetRolesService>();
builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();
builder.Services.AddScoped<IRemoveUserService, RemoveUserService>();
builder.Services.AddScoped<IUserStatusChangeService, UserStatusChangeService>();
builder.Services.AddScoped<IEditUserService, EditUserService>();
builder.Services.AddScoped<IUserLoginService, UserLoginService>();
builder.Services.AddScoped<IProductFacad, ProductFacad>();
builder.Services.AddScoped<IGetMenuItemService, GetMenuItemService>();
builder.Services.AddScoped<IGetCategoryService, GetCategoryService>();
builder.Services.AddScoped<IAddNewSliderService, AddNewSliderService>();
builder.Services.AddScoped<IGetSliderService, GetSLiderService>();
builder.Services.AddScoped<IAddHomePageImagesService, AddHomePageImagesService>();
builder.Services.AddScoped<IGetHomePageImageService, GetHomePageImagesService>();


builder.Services.AddAuthentication(options =>
{
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = new PathString("/");
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
});

var app = builder.Build();

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
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.Run();
