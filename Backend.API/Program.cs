using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data.Ef;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Backend.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            using (var serviceScope = host.Services.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<EfDbContext>();
                //ensure the current database is deleted
                context.Database.EnsureDeleted();
                //ensure the database is created
                context.Database.EnsureCreated();
                //run migrations
                //context.Database.Migrate(); 
            }
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
