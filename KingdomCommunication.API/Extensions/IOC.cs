using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UsApplication.Core.Repository;
using UsApplication.Core.Services;
using UsApplication.Implementation.Hubs;
using UsApplication.Implementation.Repositories;
using UsApplication.Implementation.Services;
using UsApplication.Models;

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
            services.AddScoped<IImageService, ImageService>();
            //services.AddSingleton<IUserIdProvider, CustomIdentityProvider>();


        }

        /// <summary>
        /// AddConfiguration method
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddConfigureSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AccountSettings>(configuration.GetSection("AccountSettings"));
        }
    }
}
