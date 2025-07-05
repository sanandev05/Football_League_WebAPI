using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;

namespace Football_League.BLL
{
    public static class BLLServiceRegistration
    {
        public static IServiceCollection AddBLLServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
