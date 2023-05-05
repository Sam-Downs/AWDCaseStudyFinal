using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models;
using SportsPro.Models.Configuration;
using SportsPro.Models.DomainModels;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMemoryCache();
builder.Services.AddSession();


// Add services to the container.
builder.Services.AddControllersWithViews();

//Add EF core dependancy injection
builder.Services.AddDbContext<SportsProFinalContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SportsProFinalContext")));

builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.AppendTrailingSlash = true;
});

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;

}).AddEntityFrameworkStores<SportsProFinalContext>()
  .AddDefaultTokenProviders();

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

app.UseAuthentication();
app.UseAuthorization();

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    await ConfigureIdentity.CreateAdminUserAsync(scope.ServiceProvider);
}


app.UseSession();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");
});

app.Run();
