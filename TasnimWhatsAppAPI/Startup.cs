using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TansimWhatsAppOrchestration.Tests;
using TasnimWhatsAppOrchestration.Models;
using TasnimWhatsAppOrchestration.WorkingWithData;
using TasnimWhatsAppOrchestration.WorkingWithData.Husoomat;
using TasnimWhatsAppOrchestration.WorkingWithData.SkinCareCenter;

namespace TasnimWhatsAppAPI
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

            services.AddControllers();

       
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<TasnimContext>(options =>
            options.UseSqlServer(connection)
            );


            services.AddScoped<IGetAndSetDataForTheCenter, GetAndSetDataForTheCenter>();

            services.AddScoped<IGetAndSetDataForHusoomat, GetAndSetDataForHusoomat>();

            services.AddScoped<IGetAndSetData, GetAndSetData>();

            services.AddScoped<ITasnimContext, TasnimContext>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TasnimWhatsAppAPI", Version = "v1" });

            });


            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => 
                    {
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TasnimWhatsAppAPI v1");
                      //  c.SwaggerEndpoint("TasnimWhatsAppAPI/swagger/v1/swagger.json", "TasnimWhatsAppAPI v1");
                      //  c.RoutePrefix = string.Empty;
                    }
                );
            }

            else
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                     c.SwaggerEndpoint("swagger/v1/swagger.json", "TasnimWhatsAppAPI v1");
                   // c.SwaggerEndpoint("TasnimWhatsAppAPI/swagger/v1/swagger.json", "TasnimWhatsAppAPI v1");
                    c.RoutePrefix = string.Empty;
                }
                );
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

        


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
