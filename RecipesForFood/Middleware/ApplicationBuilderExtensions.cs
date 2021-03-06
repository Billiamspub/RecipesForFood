﻿using Microsoft.Extensions.FileProviders;
using System.IO;

// optional change but seems to be a Microsoft uses and appears in intellisense
//namespace RecipesForFood.Middleware
namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseNodeModules(
                this IApplicationBuilder app, string root
            )
        {
            var path = Path.Combine(root, "node_modules");
            var fileProvider = new PhysicalFileProvider(path);
            var options = new StaticFileOptions();
            options.RequestPath = "/node_modules";
            options.FileProvider = fileProvider;
            app.UseStaticFiles(options);

            return app;

        }
    }
}
