using Microsoft.Extensions.DependencyInjection;
using ups.micros.chat.application.interfaces.service;
using ups.micros.chat.application.services;

namespace ups.micros.chat.application.ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjectionApplication(this IServiceCollection services)
        {

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ISignalrService, SignalrService>();
            services.AddScoped<IUserChatService, UserChatService>();

            return services;
        }
    }
}
