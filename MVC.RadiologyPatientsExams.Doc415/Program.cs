using Microsoft.EntityFrameworkCore;
using RadiologyPatientsExams.Data;
using RadiologyPatientsExams.Repositories;
using RadiologyPatientsExams.Services;
using System.Configuration;

namespace RadiologyPatientsExams
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IRadiologyPatientRepository, PatientRepository>();
            builder.Services.AddScoped<PatientService>();
            builder.Services.AddScoped<Validations.BirthDateValidation>();
            
            builder.Services.AddScoped<IRadiologyExamRepository, ExamRepository>();
            builder.Services.AddScoped<ExamService>();

            builder.Services.AddScoped<Seeder>();

            builder.Services.AddDbContextFactory<RadiologyDb>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("RadiologyDb") ?? throw new InvalidOperationException("Connection string 'RadiologyDb' not found.")));


            var app = builder.Build();


            var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<RadiologyDb>();
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            
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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Patient}/{action=Index}/{id?}");
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Exam}/{action=Index}/{id?}");

            app.Run();
        }

        
    }
}
