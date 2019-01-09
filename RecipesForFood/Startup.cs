using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RecipesForFood.Data;
using RecipesForFood.Services;

namespace RecipesForFood
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // app.UseAuthentication(); depends on the following
            // add defaults and set up with methods
            // can set options in AddOpenIdConnect individually but he uses bind as 
            // a shortcut
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddOpenIdConnect(options =>
            {
                _configuration.Bind("AzureAd", options);
            })
            .AddCookie();

            // AddSingleton or AddTransient or AddScoped
            services.AddSingleton<IGreeter, Greeter>();
            services.AddDbContext<RecipesForFoodDBContext>(
                options => options.UseSqlServer(_configuration.GetConnectionString("RecipesForFood")));
            //services.AddSingleton<IRecipeData, InMemoryRestaurantData>();
            services.AddScoped<IRecipeData, SqlRecipeData>();
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
            // all pages will use SSL
            app.UseRewriter(new RewriteOptions().AddRedirectToHttpsPermanent());
            // middleware to look at incoming request and if for a directory will look for a default file; could specify with options parameter
            //app.UseDefaultFiles();
            //// middleware for allowing static files in www
            //app.UseStaticFiles();
            // does both of above with options parameter
            //app.UseFileServer();

            app.UseStaticFiles();

            app.UseNodeModules(env.ContentRootPath);

            app.UseAuthentication();

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

            //app.Run(async (context) =>
            //{                
            //    //var appTitle = configuration["AppTitle"];
            //    var appTitle = greeter.GetTitleOfTheDay();
            //    await context.Response.WriteAsync($"{appTitle} : {env.EnvironmentName}");
            //});
        }
    }
}
