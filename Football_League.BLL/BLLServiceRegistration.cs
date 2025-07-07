using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using Football_League.BLL.Services;
using Football_League.BLL.Services.Interfaces;

namespace Football_League.BLL
{
    public static class BLLServiceRegistration
    {
        public static IServiceCollection AddBLLServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped<IStadiumService, StadiumService>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<IMatchService, MatchService>();
            services.AddScoped<IPlayerService, PlayerService>();

            return services;
        }
    }
}
