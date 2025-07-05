using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Football_League.BLL.Dtos.Dtos;

namespace Football_League.BLL.Services.Interfaces
{
    public interface IStatsService
    {
        Task<TeamStatsReportDto> GetTeamStatsAsync(int teamId);
        Task<IEnumerable<LeagueStandingDto>> GetLeagueStandingsAsync();
        Task<IEnumerable<TopScoringPlayerDto>> GetTopScoringPlayersAsync();
    }
}
