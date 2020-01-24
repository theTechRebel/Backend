using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Core.Extensions
{
    public static class CorsServiceExtension
    {
        private static readonly string BackEndOrigins = "_backendUiOrigins";

        public static IServiceCollection AddCorsForApp(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddCors(options =>
            {
                options.AddPolicy(BackEndOrigins,
                builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            return services;
        }

        public static IApplicationBuilder UseCorsForApp(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(BackEndOrigins);
            app.UseAuthorization(); //must appear here in order for Authorization to work
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
            return app;
        }
    }
}
