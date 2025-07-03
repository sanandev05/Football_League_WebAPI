using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.DAL.Entities
{
    public class Stadium : BaseEntity
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public ICollection<Team> Teams { get; set; } = new List<Team>();
    }
}
