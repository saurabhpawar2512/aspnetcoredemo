using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DemoApp
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IPersonRepo, PersonRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseDefaultFiles();
            //app.UseStaticFiles();

            // app.UseFileServer();
            app.UseMvcWithDefaultRoute();
                        
            app.Use(async (context, next) =>
            {
                context.Response.WriteAsync("Middleware1 Request");
                await next();
                context.Response.WriteAsync("Middleware1 Response");
            });

            app.Run(async (context) =>
            {
                context.Response.WriteAsync("Middleware2 Request");
                context.Response.WriteAsync("Middleware2 Response");
            });

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Middleware1");
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync(_config["MyKey"]);
            //});
        }
    }
}
