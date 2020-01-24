using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Backend.Core.Extensions
{
    public static class SwaggerServiceExtension
    {
        private static readonly string ApiVersion = "v1";
        private static readonly string ApiName = "Backend API";
        private static readonly string ApiDescription = ".Net Core C# Backend";

        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(ApiVersion, new OpenApiInfo
                {
                    Title = ApiName,
                    Version = ApiVersion,
                    Description = ApiDescription,
                    Contact = new OpenApiContact
                    {
                        Name = "Tinashe Dumbura",
                        Email = "stevedumbura@gmail.com",
                        Url = new Uri("https://twitter.com/thetechrebel"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under MIT Open Licence",
                        Url = new Uri("https://example.com/license"),
                    }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
      {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              },
              Scheme = "oauth2",
              Name = "Bearer",
              In = ParameterLocation.Header,

            },
            new List<string>()
          }
        });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", ApiName);
                c.DocumentTitle = ApiDescription;
                c.DocExpansion(DocExpansion.None);
            });
            return app;
        }
    }
}
