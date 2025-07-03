using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.DAL.Entities
{
    public class Player : BaseEntity
    {
        public string FullName { get; set; }
        public int JerseyNumber { get; set; }
        public int GoalsScored { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public ICollection<MatchGoal> MatchGoals { get; set; } = new List<MatchGoal>();
    }
}
