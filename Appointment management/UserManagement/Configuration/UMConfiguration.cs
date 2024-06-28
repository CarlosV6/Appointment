using FluentValidation;
using HelperModels;

namespace UserManagement.Configuration
{
    public static class UMConfiguration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(UMConfiguration).Assembly;

            ConfigureRabbitMQSource(services, configuration);
            ConfigureRabbitMQDestination(services, configuration);

            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));
            services.AddValidatorsFromAssembly(assembly);

            return services;
        }
        private static void ConfigureRabbitMQSource(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConfigurationRabbitMQ>("RabbitMQSource", configuration.GetSection("RabbitMQConfiguration:Source"));
            services.AddSingleton<ConfigurationRabbitMQ>();
        }
        private static void ConfigureRabbitMQDestination(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConfigurationRabbitMQ>("RabbitMQDestination", configuration.GetSection("RabbitMQConfiguration:Destination"));
            services.AddSingleton<ConfigurationRabbitMQ>();
        }
    }
}
