using Backend.Core.Extensions;
using Backend.Data.Ef;
using Backend.Services.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Backend.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            string conn = "";
            if (env.IsDevelopment())
            {
                conn = Configuration["ConnectionStrings:DevBackEndDBContext"];
                if (conn.Contains("%CONTENTROOTPATH%"))
                {
                    conn = conn.Replace("%CONTENTROOTPATH%", env.ContentRootPath);
                }
            }
            _connection = conn;

        }

        public IConfiguration Configuration { get; }
        private readonly string _connection;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddSingleton(Configuration);

            services.AddSwaggerDocumentation();
            services.AddCorsForApp();
            services.AddJwt(Configuration);

            services.AddDependencyInjection();
            services.AddDbContext<EfDbContext>(options =>
                options.UseSqlServer(_connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwaggerDocumentation();
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./v1/swagger.json", "Backend API V1"); //originally "./swagger/v1/swagger.json"
            });

            app.UseCorsForApp();
            app.UseJwt();
        }
    }
}
