using KUMF5H_HFT_2021221.Data;
using KUMF5H_HFT_2021221.Endpoint.Services;
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
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace KUMF5H_HFT_2021221.Endpoint
{
    public class Startup
    {


        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";





        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
          

            services.AddTransient<DbContext, MedDbContext>();

            services.AddTransient<IPatientLogic, PatientLogic>();
            services.AddTransient<IPatientRepository, PatientRepository>();

            services.AddTransient<IMedicineLogic, MedicineLogic>();
            services.AddTransient<IMedicineRepository, MedicineRepository>();

            services.AddTransient<IProducerLogic, Producerlogic>();
            services.AddTransient<IProducerReposiotory, Producerrepository>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins("http://example.com",
                                                          "http://www.contoso.com",
                                                          "http://127.0.0.1:5500",
                                                          "http://127.0.0.1",
                                                          "127.0.0.1",
                                                          "localhost"

                                                          )
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
            });
            });





            services.AddSignalR();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "KUMF5H_HFT_2021221.Endpoint", Version = "v1" });
            });






        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {





            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "KUMF5H_HFT_2021221.Endpoint v1"));
            }

            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;
                var response = new { Msg = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();


            /*
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });*/

            app.UseCors(MyAllowSpecificOrigins);


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}
