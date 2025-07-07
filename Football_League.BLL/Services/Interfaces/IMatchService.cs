using Football_League.DAL.Entities;
using static Football_League.BLL.Dtos.Dtos;

namespace Football_League.BLL.Services.Interfaces
{
    public interface IMatchService
    {
        Task<IEnumerable<MatchDto>> GetAllAsync();
        Task<MatchDto?> GetByIdAsync(int id);
        Task<MatchDto> CreateAsync(MatchSaveDto dto);
        Task UpdateAsync(int id, MatchSaveDto dto);
        Task DeleteAsync(int id);
        Task<MatchDto> CreateMatchAndUpdateStatsAsync(MatchSaveDto dto);
    }
}
