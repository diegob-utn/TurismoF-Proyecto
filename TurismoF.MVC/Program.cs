using System.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TurismoF.Data.Data;
using TurismoF.MVC.Data;

namespace TurismoF.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            var connectionData = builder.Configuration.GetConnectionString("Context");


            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDbContext<Context1>(options =>
                options.UseInMemoryDatabase("TurismoTestDB"));


            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Seed test data for demo
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<Context1>();
                SeedTestData(context);
            }

            // Configure the HTTP request pipeline.
            if(app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }

        private static void SeedTestData(Context1 context)
        {
            if (!context.Trenes.Any())
            {
                // Create a test train using the factory
                var tren = TurismoF.Modelos.Factory.TrenCompletoFactory.CrearTrenCompleto(
                    "Tren Turístico Test",
                    TurismoF.Modelos.EstadoTren.Activo,
                    cantidadVagones: 2,
                    cantidadVagonesPreferenciales: 1,
                    filasPorVagon: 4,
                    asientosPorFila: 4
                );

                context.Trenes.Add(tren);
                context.SaveChanges();
            }
        }
    }
}
