﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eshop.Microservices.Ordering.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices
        (this IServiceCollection services, IConfiguration configuration)
        {
            // Add services to the container.            

            return services;
        }
    }
}
