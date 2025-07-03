using Football_League.DAL.Data;
using Football_League.DAL.Repositories.Interfaces;
using Football_League.DAL.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Football_League.DAL
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddDalServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FootballLeagueContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<IStadiumRepository, StadiumRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IMatchRepository, MatchRepository>();
            return services;
        }
    }
}
