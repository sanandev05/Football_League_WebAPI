using Football_League.DAL.Entities;
using static Football_League.BLL.Dtos.Dtos;

namespace Football_League.BLL.Services.Interfaces
{
    public interface IMatchService
    {
        Task<Match> CreateMatchAndUpdateStatsAsync(MatchSaveDto dto);
    }
}
