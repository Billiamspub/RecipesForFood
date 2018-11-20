using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RecipesForFood.Services;

namespace RecipesForFood
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // AddSingleton or AddTransient or AddScoped
            services.AddSingleton<IGreeter, Greeter>();
            services.AddScoped<IRecipeData, InMemoryRestaurantData>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                                IHostingEnvironment env,
                                IGreeter greeter,
                                ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                //env.EnvironmentName();
                app.UseDeveloperExceptionPage();
            }
            // middleware to look at incoming request and if for a directory will look for a default file; could specify with options parameter
            //app.UseDefaultFiles();
            //// middleware for allowing static files in www
            //app.UseStaticFiles();
            // does both of above with options parameter
            //app.UseFileServer();
            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();

            //app.Use(next =>
            //{
            //    return async context =>
            //    {
            //        logger.LogInformation("Request incoming");
            //        if (context.Request.Path.StartsWithSegments("/mym"))
            //        {
            //            await context.Response.WriteAsync("Hit!!!");
            //            logger.LogInformation("Request handled");
            //        }
            //        else
            //        {
            //            await next(context);
            //            logger.LogInformation("Response outgoing");
            //        }
            //    };
            //});


            //app.UseWelcomePage(new WelcomePageOptions {
            //    Path="/wp"
            //});

            app.Run(async (context) =>
            {                
                //var appTitle = configuration["AppTitle"];
                var appTitle = greeter.GetTitleOfTheDay();
                await context.Response.WriteAsync($"{appTitle} : {env.EnvironmentName}");
            });
        }
    }
}
