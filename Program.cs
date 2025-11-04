using BBB.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BBB.Models; // XD

using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics; // XD


internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        // Add database context
        builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseLazyLoadingProxies()
               .UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders(); // XD


        var app = builder.Build();
        
        // ✅ Apply migrations automatically (optional)
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            db.Database.Migrate(); // Ensures DB and tables exist

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

            if (!await roleManager.RoleExistsAsync("Admin"))
                await roleManager.CreateAsync(new IdentityRole<int>("Admin"));

            var existingUser = await userManager.FindByNameAsync("admin");
            if (existingUser == null)
            {
                var newUser = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@example.com" // ✅ Add this
                };

                var createResult = await userManager.CreateAsync(newUser, "Admin@123");
                if (createResult.Succeeded)
                    await userManager.AddToRoleAsync(newUser, "Admin");
                else Debug.WriteLine("XD");
                
            }
        }
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();


        app.UseAuthentication(); // XD

        app.UseAuthorization();

        app.MapStaticAssets();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();


        app.Run();
    }
}

