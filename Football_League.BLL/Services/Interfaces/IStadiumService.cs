using static Football_League.BLL.Dtos.Dtos;

namespace Football_League.BLL.Services.Interfaces
{
    public interface IStadiumService
    {
        Task<IEnumerable<StadiumDto>> GetAllAsync();
        Task<StadiumDto?> GetByIdAsync(int id);
        Task<StadiumDto> CreateAsync(StadiumSaveDto dto);
        Task UpdateAsync(int id, StadiumSaveDto dto);
        Task DeleteAsync(int id);
    }
}
