using Microsoft.Extensions.DependencyInjection;
using ups.micros.chat.application.interfaces.repository;
using ups.micros.chat.application.ioc;
using ups.micros.chat.infrastructure.data.context;
using ups.micros.chat.infrastructure.data.repository;

namespace ups.micros.chat.infrastructure.ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjectionInfrastructure(this IServiceCollection services)
        {

            services.AddDependencyInjectionApplication();

            services.AddDbContext<Context>();

            services.AddScoped<IAccountRepositoy, AccountRepositoy>();
            services.AddScoped<ISignalrRepository, SignalrRepository>();
            services.AddScoped<IUserChatRepository, UserChatRepository>();

            services.AddHttpContextAccessor();

            return services;
        }
    }
}
