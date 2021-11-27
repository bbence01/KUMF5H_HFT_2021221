using KUMF5H_HFT_2021221.Data;
using KUMF5H_HFT_2021221.Logic;
using KUMF5H_HFT_2021221.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KUMF5H_HFT_2021221_Endpoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<IPatientLogic, PatientLogic>();
            services.AddTransient<IPatientRepository, PatientRepository>();

            services.AddTransient<IMedicineLogic, MedicineLogic>();
            services.AddTransient<IMedicineRepository, MedicineRepository>();

            services.AddTransient<IProducerLogic, Producerlogic>();
            services.AddTransient<IProducerReposiotory, Producerrepository>();

            services.AddTransient<DbContext, MedDbContext>();
           

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
