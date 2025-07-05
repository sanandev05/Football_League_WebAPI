using Football_League.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.DAL.Repositories.Interfaces
{
    public interface ITeamRepository : IGenericRepository<Team>
    {
        Task<bool> IsTeamNameUniqueAsync(string name, int? teamId = null);
        Task<bool> IsTeamCodeUniqueAsync(int code, int? teamId = null);
        Task<Team> GetTeamWithPlayersAsync(int teamId); 

    }
}
