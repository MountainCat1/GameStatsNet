﻿using GameStatsNet.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GameStatsNet.Api.Installers
{
    public static class DbContextInstaller
    {
        private const string DatabaseConnectionStringKey = "Database";
    
        public static IServiceCollection InstallDbContext(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<GameStatsNetDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString(DatabaseConnectionStringKey),
                    b =>
                    {
                        b.MigrationsAssembly(typeof(ApiAssemblyMarker).Assembly.FullName);
                        b.EnableRetryOnFailure(5, TimeSpan.FromSeconds(5.0), null);
                    });
            });


            return services;
        }
    }
}