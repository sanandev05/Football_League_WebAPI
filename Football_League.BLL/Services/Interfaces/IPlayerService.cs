using static Football_League.BLL.Dtos.Dtos;

namespace Football_League.BLL.Services.Interfaces
{
    public interface IPlayerService
    {
        Task<IEnumerable<PlayerDto>> GetAllAsync();
        Task<PlayerDto?> GetByIdAsync(int id);
        Task<PlayerDto> CreateAsync(PlayerSaveDto dto);
        Task UpdateAsync(int id, PlayerSaveDto dto);
        Task DeleteAsync(int id);
    }
}
