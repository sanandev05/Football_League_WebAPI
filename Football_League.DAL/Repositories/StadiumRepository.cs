using Football_League.DAL.Data;
using Football_League.DAL.Entities;
using Football_League.DAL.Repositories.Interfaces;


namespace Football_League.DAL.Repositories
{
    public class StadiumRepository : GenericRepository<Stadium>, IStadiumRepository
    {
        public StadiumRepository(FootballLeagueContext context) : base(context) { }
    }
}
