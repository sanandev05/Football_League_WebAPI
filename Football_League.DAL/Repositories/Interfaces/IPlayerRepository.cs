using Football_League.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.DAL.Repositories.Interfaces
{
    public interface IPlayerRepository : IGenericRepository<Player>
    {
        Task<bool> IsJerseyNumberUniqueAsync(int jerseyNumber, int teamId, int? playerId = null);
    }
}
