using FluentValidation;
using FluentValidation.AspNetCore;
using TeknikMarket.Business.Abstract;
using TeknikMarket.Business.Concrete;
using TeknikMarket.Business.ValidationRule.Areas.Admin;
using TeknikMarket.DataAccess.Abstract;
using TeknikMarket.DataAccess.Concrete.repository;
using TeknikMarket.Model.ViewModel.Area.Admin.User;

namespace TeknikMarket.CoreMVCUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddFluentValidationClientsideAdapters();


            //builder.Services.AddTransient();  ISTEDÝÐÝN KADAR NEWLÝYOR HER TALEPTE NEW ÝÞLEMÝNÝ TEKRAR YAPIYOR 
            //builder.Services.AddScoped(); SADECE 1 SCOPEDA GEÇERLÝ OLUYOR SONRA ÖLÜYOR 
            //builder.Services.AddSingleton(); SADECE 1 KERE KULLANILIYOR. TALEP EDÝLDÝÐÝNDE BUNU TEKRAR KULLANIYOR.

            builder.Services.AddSingleton<IKullaniciBS,KullaniciBs>();
            builder.Services.AddSingleton<IKullaniciRepository, EfKullaniciRepository>();

            //-----VALIDATION
            builder.Services.AddSingleton<IValidator<LogInViewModel>, LoginVmValidator>();


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


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

                
            });

            

            app.Run();
        }
    }
}