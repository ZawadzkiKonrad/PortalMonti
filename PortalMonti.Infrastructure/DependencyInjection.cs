using Microsoft.Extensions.DependencyInjection;
using PortalMonti.Domain.Interfaces;
using PortalMonti.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalMonti.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        { services.AddTransient<IPostRepository, PostRepository>();
            return services;
        }
    }
}
