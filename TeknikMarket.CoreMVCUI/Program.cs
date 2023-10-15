using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Data.SqlClient.DataClassification;
using Newtonsoft.Json;
using TeknikMarket.Business.Abstract;
using TeknikMarket.Business.Concrete;
using TeknikMarket.Business.ValidationRule.Areas.Admin;
using TeknikMarket.CoreMVCUI.Areas.Admin.Filter;
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
            builder.Services.AddControllersWithViews().AddNewtonsoftJson(option =>
            {
                option.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });


            //MApper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddFluentValidationClientsideAdapters();


            //builder.Services.AddTransient();  ISTEDÝÐÝN KADAR NEWLÝYOR HER TALEPTE NEW ÝÞLEMÝNÝ TEKRAR YAPIYOR 
            //builder.Services.AddScoped(); SADECE 1 SCOPEDA GEÇERLÝ OLUYOR SONRA ÖLÜYOR 
            //builder.Services.AddSingleton(); SADECE 1 KERE KULLANILIYOR. TALEP EDÝLDÝÐÝNDE BUNU TEKRAR KULLANIYOR.

            builder.Services.AddSingleton<IKullaniciBS,KullaniciBs>();
            builder.Services.AddSingleton<IKullaniciRepository, EfKullaniciRepository>();

            builder.Services.AddSingleton<IKategoriBS, KategoriBs>();
            builder.Services.AddSingleton<IKategoriRepository, EfKategoriRepository>();

            //-----VALIDATION
            builder.Services.AddSingleton<IValidator<LogInViewModel>, LoginVmValidator>();
            builder.Services.AddSingleton<IValidator<ForgotPasswordViewModel>, ForgotPasswordVmValidator>();



            //SESSÝON
            builder.Services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromDays(30);
            });

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddSingleton<ISessionManager,SessionManager>();

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

            app.UseSession();

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