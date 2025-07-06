using static Football_League.BLL.Dtos.Dtos;

namespace Football_League.BLL.Services.Interfaces
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamDto>> GetAllAsync();
        Task<TeamDto?> GetByIdAsync(int id);
        Task<TeamDto> CreateAsync(TeamSaveDto dto);
        Task UpdateAsync(int id, TeamSaveDto dto);
        Task DeleteAsync(int id);
        Task<bool> IsTeamNameUniqueAsync(string name, int? teamId = null);
        Task<bool> IsTeamCodeUniqueAsync(int code, int? teamId = null);
    }
}
