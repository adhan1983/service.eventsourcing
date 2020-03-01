using AOM.Notification.Service.Proxy.BackgroundServices;
using AOM.Notification.Service.Proxy.EmailService;
using AOM.Notification.Service.Proxy.EmailService.Interfaces;
using AOM.Notification.Service.Proxy.Helpers;
using AOM.Notification.Service.Proxy.Helpers.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace AOM.Notification.Service.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public IConfiguration Configuration { get; }        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IEmailProxyClient, EmailProxyClient>();
            services.AddTransient<IConfigurationEmailProxyClient, ConfigurationEmailProxyClient>();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Version = "v1",
                    Title = "Notification Service",
                    Description = "Development Environment for Notification Service",
                    Contact = new OpenApiContact()
                    {
                        Name = "Adhan Maldonado",
                        Email = "adhan.maldonado@gmail.com",
                    },

                });

            });

            services.AddHostedService<NewCustomerEventHandler>();
        }        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "NotificationService");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
