using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using UsApplication.Core.Repository;
using UsApplication.Core.Services;
using UsApplication.Implementation.Hubs;
using UsApplication.Implementation.Repositories;
using UsApplication.Implementation.Services;

namespace KingdomCommunication.API.Extensions
{
    public static class IOC
    {
        public static void DInjections(this IServiceCollection services)
        {
            //Repositories
            services.AddScoped<IConnectionRepository, ConnectionRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();

            //Services
            services.AddScoped<IConnectionService, ConnectionService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IUserService, UserService>();
            //services.AddSingleton<IUserIdProvider, CustomIdentityProvider>();
        }
    }
}
