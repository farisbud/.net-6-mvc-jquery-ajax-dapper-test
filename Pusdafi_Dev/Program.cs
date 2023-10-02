

using Pusdafi_Dev.Interface;
using Pusdafi_Dev.Models.Data;
using Pusdafi_Dev.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Pusdafi_Dev.Services;

#region old

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<RegisterIntf, RegisterRepo>();
builder.Services.AddScoped<LoginIntf, LoginRepo>();
builder.Services.AddScoped<CategoryIntf, CategoryRepo>();
builder.Services.AddScoped<SubCategoryIntf, SubCategoryRepo>();
builder.Services.AddScoped<SubCategoryDataIntf, SubCategoryDataSVC>();
builder.Services.AddScoped<ContenIntf, ContentRepo>();


builder.Services.AddTransient<DapperDBContext>();
builder.Services.AddSession();

builder.Services.AddAuthentication("pusdafiCookie").AddCookie("pusdafiCookie", options =>
{
    options.Cookie.Name = "pusdafiCookie";
    options.LoginPath = "/admin";
    options.LogoutPath = "/admin";
    options.AccessDeniedPath = "/admin/dashboard";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
});

#region role policy
//builder.Services.AddAuthorization(options =>
//{

//    //AdminOnly dipasang di atas method / class controller
//    //required claim ada di admincontroller claimtype 
//    options.AddPolicy("AdminOnly",
//        policy => policy.RequireClaim("Admin"));

//    //jadi autorization MustBelongHRD,bisa akses departement hrd dan claimType nya departement, HRD
//    options.AddPolicy("MustBelongHRD",
//        policy => policy.RequireClaim("Departement", "HRD"));

//    //jadi autorization HRManagerOnly,bisa akses departement hrd and manager
//    //bisa pakai 2 required claim, departement hrd and manager
//    options.AddPolicy("HRManagerOnly",
//        policy => policy.RequireClaim("Departement","HRD")
//                        .RequireClaim("Manager")                
//        );

//});
#endregion

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(options =>
//    {
//        options.Cookie.Name = "pusdafiCookie";
//        options.LoginPath = "/admin";
//        options.LogoutPath = "/admin";
//    });

//builder.Services.AddSession(options =>
//{
//    options.Cookie.Name = "pusdafiCookieSession";
//    options.IdleTimeout = TimeSpan.FromMinutes(30); // Adjust the timeout as needed
//});

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("AdminOnly", policy =>
//    {
//        policy.RequireRole("Admin");
//    });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapControllerRoute(
//    name: "admin",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
#endregion

