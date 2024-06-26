﻿using Business.Contract;
using Business.Implement;
using DataAccess.Core.Contract;
using DataAccess.Core.Implements;
using DataAccess.Models;
using DataAccess.Models.Mapper;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DependencyInjection
{
    public static class IoCRegister
    {
        public static IServiceCollection AddRepository(IServiceCollection services)
        {            
            services.AddScoped<IUnidadRepository, UnidadRepository>();
            services.AddScoped<IServicioRepository, ServicioRepository>();

            return services;
        }

        public static IServiceCollection AddServices(IServiceCollection services)
        {            
            services.AddScoped<IUnidadServices, UnidadServices>();
            services.AddScoped<IServicioServices, ServicioServices>();
            services.AddAutoMapper(typeof(UnidadProfileMap));
            services.AddAutoMapper(typeof(ServicioProfileMap));

            return services;
        }

        public static IServiceCollection AddDbContext(IServiceCollection services, string DefaultConnection)
        {
            var connection = new SqliteConnection(DefaultConnection);
            connection.Open();
            connection.EnableExtensions(true);
            services.AddDbContext<DbCrudContext>(options => options.UseSqlite(DefaultConnection));           

            return services;
        }
    }
}
