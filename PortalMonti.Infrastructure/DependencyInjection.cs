using Microsoft.Extensions.DependencyInjection;
using PortalMonti.Domain.Interfaces;
using PortalMonti.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PortalMonti.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        { services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IFriendRepository, FriendRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IImageRepository, ImageRepopsitory>();
            
            
            return services;
        }
    }
}
