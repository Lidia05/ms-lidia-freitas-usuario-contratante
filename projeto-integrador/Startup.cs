using Microsoft.ApplicationInsights.DependencyCollector;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using projeto_integrador.Configuration;
using projeto_integrador.Data;
using projeto_integrador.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_integrador
{
    public class Startup
    {
        public Startup(IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(hostEnvironment.ContentRootPath)
               .AddJsonFile("appsettings.json", true, true)
               .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
               .AddEnvironmentVariables();

            Configuration = builder.Build();
            Configuration.Bind("AppSettings", new AppSettings());
        }


        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddControllers();
            services.AddResponseCompression();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "api.projeto.integrador", Version = "v1" });
            });

            services.AddScoped<DataContext>();

            services.AddDbContext<DataContext>(options =>
               options.UseNpgsql(Environment.GetEnvironmentVariable("ConnectionString")));


            services.AddTransient<IUsuarioContratanteRepository, UsuarioContratanteRepository>();


            if (!string.IsNullOrEmpty(Configuration["ApplicationInsights:InstrumentationKey"]))
            {
                services.AddApplicationInsightsTelemetry(Configuration);
                services.ConfigureTelemetryModule<DependencyTrackingTelemetryModule>((module, o) =>{
                    module.EnableSqlCommandTextInstrumentation = true;
                    module.EnableAzureSdkTelemetryListener = true;
                    
                });
            }
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "api.projeto.integrador v1"));

            }

            app.UseHttpsRedirection();

            app.UseCors(options =>
               options.
                   AllowAnyOrigin().
                   AllowAnyMethod().
                   AllowAnyHeader()

               );


            dbContext.Database.Migrate();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
