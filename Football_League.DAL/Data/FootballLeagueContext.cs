using Football_League.DAL.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Football_League.DAL.Data
{
    public class FootballLeagueContext : DbContext
    {
        public FootballLeagueContext(DbContextOptions<FootballLeagueContext> options) : base(options) { }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchGoal> MatchGoals { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(cancellationToken);
        }
        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries<BaseEntity>();
            var now = DateTime.Now;
            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedTime = now;
                        entry.Entity.IsDeleted = false;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdateTime = now;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Entity.IsDeleted = true;
                        entry.Entity.UpdateTime = now;
                        break;
                }
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Team>().HasQueryFilter(t => !t.IsDeleted);
            modelBuilder.Entity<Stadium>().HasQueryFilter(s => !s.IsDeleted);
            modelBuilder.Entity<Player>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Match>().HasQueryFilter(m => !m.IsDeleted);
            modelBuilder.Entity<MatchGoal>().HasQueryFilter(mg => !mg.IsDeleted);
        }
    }
}
