using Football_League.DAL.Data;
using Football_League.DAL.Entities;
using Football_League.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Football_League.DAL.Repositories
{
    public class PlayerRepository : GenericRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(FootballLeagueContext context) : base(context) { }
        public async Task<bool> IsJerseyNumberUniqueAsync(int jerseyNumber, int teamId, int? playerId = null)
        {
            return !await _dbSet.AnyAsync(p => p.TeamId == teamId && p.JerseyNumber == jerseyNumber && p.Id != playerId);
        }
        public async Task<IEnumerable<Player>> GetTopScorersAsync()
        {
            return await _dbSet
                .Include(p => p.Team)
                .Where(p => p.GoalsScored > 0)
                .OrderByDescending(p => p.GoalsScored)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
