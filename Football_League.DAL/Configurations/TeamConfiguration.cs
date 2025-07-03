using Football_League.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.DAL.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).IsRequired().HasMaxLength(100);
            builder.Property(t => t.Code).IsRequired();
            builder.HasIndex(t => t.Name).IsUnique();
            builder.HasIndex(t => t.Code).IsUnique();
            builder.HasOne(t => t.Stadium).WithMany(s => s.Teams).HasForeignKey(t => t.StadiumId);
            builder.HasMany(t => t.HomeMatches).WithOne(m => m.HomeTeam).HasForeignKey(m => m.HomeTeamId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(t => t.AwayMatches).WithOne(m => m.AwayTeam).HasForeignKey(m => m.AwayTeamId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
