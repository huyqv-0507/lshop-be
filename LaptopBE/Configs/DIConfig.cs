using System;
using Data.Infrastructures;
using Data.Infrastructures.IRepositories;
using Data.Infrastructures.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Services.IServices;
using Services.Services;

namespace LaptopBE.Configs
{
    public class DIConfig
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IDbFactory, DbFactory>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ILaptopRepository, LaptopRepository>();


            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ILaptopService, LaptopService>();
            services.AddTransient<IPaymentService, PaymentService>();
        }
    }
}
