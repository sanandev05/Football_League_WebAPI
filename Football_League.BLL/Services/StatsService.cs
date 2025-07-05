using Football_League.BLL.Services.Interfaces;
using Football_League.DAL.Repositories.Interfaces;
using static Football_League.BLL.Dtos.Dtos;

namespace Football_League.BLL.Services
{
    public class StatsService : IStatsService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IPlayerRepository _playerRepository;

        public StatsService(ITeamRepository teamRepository, IPlayerRepository playerRepository)
        {
            _teamRepository = teamRepository;
            _playerRepository = playerRepository;
        }

        public async Task<TeamStatsReportDto> GetTeamStatsAsync(int teamId)
        {
            var team = await _teamRepository.GetTeamWithPlayersAsync(teamId);
            if (team == null) return null;

            var played = team.Wins + team.Draws + team.Losses;
            var points = (team.Wins * 3) + team.Draws;
            return new TeamStatsReportDto(
                team.Name,
                played,
                team.Wins,
                team.Draws,
                team.Losses,
                team.GoalsFor,
                team.GoalsAgainst,
                team.GoalsFor - team.GoalsAgainst,
                points,
                team.Players.Select(p => new PlayerStatsDto(p.FullName, p.JerseyNumber, p.GoalsScored)).OrderByDescending(p => p.GoalsScored)
            );
        }

        public async Task<IEnumerable<LeagueStandingDto>> GetLeagueStandingsAsync()
        {
            var teams = await _teamRepository.GetAllAsync();
            return teams.Select(team => new
            {
                Team = team,
                Played = team.Wins + team.Draws + team.Losses,
                Points = (team.Wins * 3) + team.Draws,
                GoalDifference = team.GoalsFor - team.GoalsAgainst
            })
            .OrderByDescending(x => x.Points)
            .ThenByDescending(x => x.GoalDifference)
            .ThenByDescending(x => x.Team.GoalsFor)
            .Select((x, index) => new LeagueStandingDto(
                index + 1,
                x.Team.Name,
                x.Played,
                x.Team.Wins,
                x.Team.Draws,
                x.Team.Losses,
                x.Team.GoalsFor,
                x.Team.GoalsAgainst,
                x.GoalDifference,
                x.Points
            )).ToList();
        }

        public async Task<IEnumerable<TopScoringPlayerDto>> GetTopScoringPlayersAsync()
        {
            var players = await _playerRepository.GetTopScorersAsync();
            return players.Select((p, index) => new TopScoringPlayerDto(
                index + 1,
                p.FullName,
                p.Team.Name,
                p.GoalsScored
            ));
        }
    }
}
