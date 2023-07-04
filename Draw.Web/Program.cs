using Draw.DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PostSharp.Extensibility;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

       

        // Add services to the container.
        builder.Services.AddControllersWithViews().AddNewtonsoftJson(options => {
            options.SerializerSettings.Formatting = Formatting.Indented;
        }); ;

        using (DrawContext context = new DrawContext())
        {
            //context.Database.EnsureCreated();
            var pendingMigrations = context.Database.GetPendingMigrations();
            if (pendingMigrations.Any())
                context.Database.Migrate();
        }

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}