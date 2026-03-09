using ASPNETCore.Data;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            


            // Configure the HTTP request pipeline.
            app.UseStaticFiles();

            app.UseStatusCodePagesWithReExecute("/Home/Error", "?kodChyby={0}"); // Přesměrování na akci HomeController.Error pro zobrazení chybových stránek

            app.UseRouting();

            app.UseAuthorization();

       

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
