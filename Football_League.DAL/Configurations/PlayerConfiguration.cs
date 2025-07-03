using Football_League.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Football_League.DAL.Configurations
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.FullName).IsRequired().HasMaxLength(150);
            builder.Property(p => p.JerseyNumber).IsRequired();
            builder.HasOne(p => p.Team).WithMany(t => t.Players).HasForeignKey(p => p.TeamId);
            builder.HasIndex(p => new { p.TeamId, p.JerseyNumber }).IsUnique();
        }
    }
}
