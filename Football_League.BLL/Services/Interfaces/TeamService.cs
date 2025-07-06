
using AutoMapper;
using Football_League.DAL.Entities;
using Football_League.DAL.Repositories.Interfaces;
using static Football_League.BLL.Dtos.Dtos;

namespace Football_League.BLL.Services.Interfaces
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;

        public TeamService(ITeamRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TeamDto>> GetAllAsync()
        {
            var teams = await _teamRepository.GetAllAsync(t => t.Stadium);
            return teams.Select(team => _mapper.Map<TeamDto>(team));
        }

        public async Task<TeamDto?> GetByIdAsync(int id)
        {
            var team = await _teamRepository.GetByIdAsync(id);
            return team == null ? null : _mapper.Map<TeamDto>(team);
        }

        public async Task<TeamDto> CreateAsync(TeamSaveDto dto)
        {
            if (!await IsTeamNameUniqueAsync(dto.Name))
                throw new Exception("Komanda adı artıq mövcuddur.");

            if (!await IsTeamCodeUniqueAsync(dto.Code))
                throw new Exception("Komanda kodu artıq istifadə olunub.");

            var team = new Team
            {
                Name = dto.Name,
                Code = dto.Code,
                StadiumId = dto.StadiumId,
                Wins = 0,
                Draws = 0,
                Losses = 0,
                GoalsFor = 0,
                GoalsAgainst = 0
            };

            await _teamRepository.AddAsync(team);
            return _mapper.Map<TeamDto>(team);
        }

        public async Task UpdateAsync(int id, TeamSaveDto dto)
        {
            var team = await _teamRepository.GetByIdAsync(id);
            if (team == null)
                throw new Exception("Komanda tapılmadı.");

            if (!await IsTeamNameUniqueAsync(dto.Name, id))
                throw new Exception("Komanda adı artıq mövcuddur.");

            if (!await IsTeamCodeUniqueAsync(dto.Code, id))
                throw new Exception("Komanda kodu artıq istifadə olunub.");

            team.Name = dto.Name;
            team.Code = dto.Code;
            team.StadiumId = dto.StadiumId;

             _teamRepository.Update(team);
        }

        public async Task DeleteAsync(int id)
        {
            var team = await _teamRepository.GetByIdAsync(id);
            if (team == null)
                throw new Exception("Komanda tapılmadı.");

            _teamRepository.Delete(team);
        }

        public Task<bool> IsTeamNameUniqueAsync(string name, int? teamId = null)
        {
            return _teamRepository.AnyAsync(t => t.Name == name && t.Id != teamId);
        }

        public Task<bool> IsTeamCodeUniqueAsync(int code, int? teamId = null)
        {
            return _teamRepository.AnyAsync(t => t.Code == code && t.Id != teamId);
        }
    }
}
