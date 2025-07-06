using Football_League.BLL.Mapping;
using Football_League.BLL.Services;
using Football_League.BLL.Services.Interfaces;
using Football_League.DAL.Data;
using Football_League.DAL.Entities;
using Football_League.DAL.Repositories;
using Football_League.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Football_League.WepAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<FootballLeagueContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StudentAppDb")));

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<ITeamRepository, TeamRepository>();
            builder.Services.AddScoped<ITeamService, TeamService>();
            builder.Services.AddScoped<IStadiumRepository, StadiumRepository>();
            builder.Services.AddScoped<IStadiumService, StadiumService>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
