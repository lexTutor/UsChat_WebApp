using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KingdomCommunication.API.Extensions
{
    public static class Authentication
    {
        public static void UseJWTAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
         .AddJwtBearer(options =>
         {
             options.SecurityTokenValidators.Clear();
             options.SecurityTokenValidators.Add(new NameTokenValidator());
             options.Events = new JwtBearerEvents
             {
                 OnMessageReceived = context =>
                 {
                     var accessToken = context.Request.Query["access_token"];

                     var path = context.HttpContext.Request.Path;
                     if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/ChatHub"))
                     {
                         context.Token = accessToken;
                     }

                     return Task.CompletedTask;
                 }
             };
         });

            services.AddAuthorization(options => {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                    .RequireClaim(ClaimTypes.Name)
                    .Build();
            });


        }
    }
}
