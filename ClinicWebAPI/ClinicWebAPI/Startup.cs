using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicWebAPI.Database;
using ClinicWebAPI.Models;
using ClinicWebAPI.Repositories;
using ClinicWebAPI.Repositories.Consultations;
using ClinicWebAPI.Repositories.Patients;
using ClinicWebAPI.Repositories.Users;
using ClinicWebAPI.Services.Consultations;
using ClinicWebAPI.Services.Patients;
using ClinicWebAPI.Services.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSession();
            services.AddMvc();
            services.AddTransient<DBConnectionWrapper>(_ => new DBConnectionFactory().GetConnectionWrapper(false));

            services.AddScoped<IUserRepository, UserRepositoryMySQL>();
            services.AddScoped<IBaseRepository<Patient>, PatientRepositoryMySQL>();
            services.AddScoped<IConsultationRepository, ConsultationRepositoryMySQL>();
            services.AddScoped<IAuthenticationService, AuthenticationServiceMySQL>();
            services.AddScoped<IAdminService, AdminServiceMySQL>();
            services.AddScoped<IPatientService, PatientServiceMySQL>();
            services.AddScoped<IConsultationService, ConsultationServiceMySQL>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Login}/{id?}");
            });
        }
    }
}
