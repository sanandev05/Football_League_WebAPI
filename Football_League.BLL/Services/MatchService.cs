using AutoMapper;
using Football_League.BLL.Services.Interfaces;
using Football_League.DAL.Entities;
using Football_League.DAL.Repositories.Interfaces;
using static Football_League.BLL.Dtos.Dtos;

namespace Football_League.BLL.Services
{
    public class MatchService : IMatchService
    {
        private readonly IGenericRepository<Match> _matchRepository;
        private readonly IMapper _mapper;

        public MatchService(IGenericRepository<Match> matchRepository, IMapper mapper)
        {
            _matchRepository = matchRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MatchDto>> GetAllAsync()
        {
            var matches = await _matchRepository.GetAllAsync();
            return matches.Select(m => _mapper.Map<MatchDto>(m));
        }

        public async Task<MatchDto?> GetByIdAsync(int id)
        {
            var match = await _matchRepository.GetByIdAsync(id);
            return match == null ? null : _mapper.Map<MatchDto>(match);
        }

        public async Task<MatchDto> CreateAsync(MatchSaveDto dto)
        {
            var match = _mapper.Map<Match>(dto);
            await _matchRepository.AddAsync(match);
            return _mapper.Map<MatchDto>(match);
        }

        public async Task UpdateAsync(int id, MatchSaveDto dto)
        {
            var match = await _matchRepository.GetByIdAsync(id);
            if (match == null)
                throw new Exception("Match not found.");

            _mapper.Map(dto, match);
            await _matchRepository.Update(match);
        }

        public async Task DeleteAsync(int id)
        {
            var match = await _matchRepository.GetByIdAsync(id);
            if (match == null)
                throw new Exception("Match not found.");

            await _matchRepository.Delete(match);
        }

        public async Task<MatchDto> CreateMatchAndUpdateStatsAsync(MatchSaveDto dto)
        {
            var match = _mapper.Map<Match>(dto);
            await _matchRepository.AddAsync(match);

            return _mapper.Map<MatchDto>(match);
        }
    }
}
