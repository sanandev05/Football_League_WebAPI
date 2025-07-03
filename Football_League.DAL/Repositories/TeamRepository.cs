using Football_League.DAL.Data;
using Football_League.DAL.Entities;
using Football_League.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Football_League.DAL.Repositories
{
    public class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        public TeamRepository(FootballLeagueContext context) : base(context) { }
        public async Task<bool> IsTeamNameUniqueAsync(string name, int? teamId = null)
        {
            return !await _dbSet.AnyAsync(t => t.Name == name && t.Id != teamId);
        }
        public async Task<bool> IsTeamCodeUniqueAsync(int code, int? teamId = null)
        {
            return !await _dbSet.AnyAsync(t => t.Code == code && t.Id != teamId);
        }
    }
}
