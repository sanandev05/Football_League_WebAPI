namespace Football_League.DAL.Entities
{
    public class Stadium : BaseEntity
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public ICollection<Team> Teams { get; set; } = new List<Team>();
    }
}
