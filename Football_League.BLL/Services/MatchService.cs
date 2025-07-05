using AutoMapper;
using Football_League.BLL.Services.Interfaces;
using Football_League.DAL.Data;
using Football_League.DAL.Entities;
using Football_League.DAL.Repositories.Interfaces;
using static Football_League.BLL.Dtos.Dtos;

namespace Football_League.BLL.Services
{
    public class MatchService : IMatchService
    {
        private readonly IMapper _mapper;
        private readonly ITeamRepository _teamRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IMatchRepository _matchRepository;
        private readonly FootballLeagueContext _context; // For transaction management only

        public MatchService(
            IMapper mapper,
            ITeamRepository teamRepository,
            IPlayerRepository playerRepository,
            IMatchRepository matchRepository,
            FootballLeagueContext context)
        {
            _mapper = mapper;
            _teamRepository = teamRepository;
            _playerRepository = playerRepository;
            _matchRepository = matchRepository;
            _context = context;
        }

        public async Task<Match> CreateMatchAndUpdateStatsAsync(MatchSaveDto dto)
        {
            var homeTeam = await _teamRepository.GetByIdAsync(dto.HomeTeamId);
            var awayTeam = await _teamRepository.GetByIdAsync(dto.AwayTeamId);
            if (homeTeam == null || awayTeam == null)
                throw new Exception("One or both teams not found.");

            homeTeam.GoalsFor += dto.HomeTeamGoals;
            homeTeam.GoalsAgainst += dto.AwayTeamGoals;
            awayTeam.GoalsFor += dto.AwayTeamGoals;
            awayTeam.GoalsAgainst += dto.HomeTeamGoals;

            if (dto.HomeTeamGoals > dto.AwayTeamGoals)
            {
                homeTeam.Wins++;
                awayTeam.Losses++;
            }
            else if (dto.AwayTeamGoals > dto.HomeTeamGoals)
            {
                awayTeam.Wins++;
                homeTeam.Losses++;
            }
            else
            {
                homeTeam.Draws++;
                awayTeam.Draws++;
            }
            _teamRepository.Update(homeTeam);
            _teamRepository.Update(awayTeam);

            foreach (var scorerDto in dto.GoalScorers)
            {
                var player = await _playerRepository.GetByIdAsync(scorerDto.PlayerId);
                if (player != null)
                {
                    player.GoalsScored += scorerDto.GoalsCount;
                    _playerRepository.Update(player);
                }
            }

            var match = _mapper.Map<Match>(dto);
            await _matchRepository.AddAsync(match);

            await _context.SaveChangesAsync();

            return match;
        }
    }
}
