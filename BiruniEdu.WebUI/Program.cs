using Autofac;
using Autofac.Extensions.DependencyInjection;
using BiruniEdu.Business.Abstract;
using BiruniEdu.Business.Concrete;
using BiruniEdu.Business.Dependencies;
using BiruniEdu.DataAccess.Dal.Abstract;
using BiruniEdu.DataAccess.Dal.Concrete;
using BiruniEdu.WebUI.AuthHelper;
using BiruniEdu.WebUI.AuthHelpers;
using BiruniEdu.WebUI.Middlewares;
using BiruniEdu.WebUI.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
   // options.Filters.Add(new AuthorizeFilter());
} );

builder.Services.AddHttpContextAccessor();

builder.Services.AddMemoryCache();

//builder.Services.AddScoped<ICacheManager, MemoryCacheManager>();
builder.Services.AddScoped<ICacheManager, RedisCacheManager>();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => 
    
    containerBuilder.RegisterModule(new DependencyInjector())
    );




builder.Services.AddSingleton<AuthHelper>();

var cookieAuthOptions = builder.Configuration.GetSection("CookieAuthOptions").Get<CookieAuthOptions>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.AccessDeniedPath = cookieAuthOptions.AccessDeniedPath;
    options.LoginPath = cookieAuthOptions.LoginPath;
    options.LogoutPath = cookieAuthOptions.LogOutPath;
    options.Cookie.Name = cookieAuthOptions.Name;
    options.SlidingExpiration = cookieAuthOptions.SlidingExpiration;
    options.ExpireTimeSpan = TimeSpan.FromSeconds(cookieAuthOptions.TimeOut);
    
});


var app = builder.Build();



//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

#region 01-Simple Middlewares

//app.Use(async (context, next) =>
//{
//    //request modifiye eder

//    Console.WriteLine($"Request Kontrol 1: {context.Request.Method} - {context.Request.Path}");

//    await next.Invoke();

//    Console.WriteLine($"Response Kontrol 1: {context.Response.ContentType} - {context.Response.StatusCode}");
//    //response modifiye eder


//});
//app.Use(async (context, next) =>
//{
//    //request modifiye eder

//    Console.WriteLine($"Request Kontrol 2: {context.Request.Method} - {context.Request.Path}");

//    await next.Invoke();

//    Console.WriteLine($"Response Kontrol 2: {context.Response.ContentType} - {context.Response.StatusCode}");
//    //response modifiye eder


//});
//app.Use(async (context, next) =>
//{
//    //request modifiye eder

//    Console.WriteLine($"Request Kontrol 3: {context.Request.Method} - {context.Request.Path}");

//    await next.Invoke();

//    Console.WriteLine($"Response Kontrol 3: {context.Response.ContentType} - {context.Response.StatusCode}");
//    //response modifiye eder


//});

#endregion

//app.UseMiddleware<RequestLoggerMiddleware>();

app.UseRequestLogger();

//app.UseIpLogger();

//app.UseIpFilter();


//********************

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCookiePolicy();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
