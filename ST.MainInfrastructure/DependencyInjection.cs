﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ST.Application.Commons.Abstractions;
using ST.Domain.Commons.Abstractions;
using ST.Domain.Data;
using ST.MainInfrastructure.Common.Authentication;
using ST.MainInfrastructure.Common.Cryptography;
using ST.MainInfrastructure.Data;

namespace ST.MainInfrastructure{
    public static class DependencyInjection{
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    optionsBuilder => optionsBuilder
                        .MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            //DI UnitOfWork
            services.AddScoped<IUnitOfWork, ApplicationDbContext>();

            //DI Authentication
            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddScoped<IPasswordHashChecker, PasswordHasher>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            return services;
        }
    }
}