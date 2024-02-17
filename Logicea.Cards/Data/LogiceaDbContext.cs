using Logicea.Cards.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Logicea.Cards.Data
{
    public class LogiceaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public LogiceaDbContext(DbContextOptions<LogiceaDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Card>(entity =>
            {
                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(e => e.Color)
                 .IsRequired()
                 .HasMaxLength(7);
            });

            builder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email)
                .IsRequired();
                entity.Property(e => e.Role)
               .IsRequired();
                entity.Property(e => e.PasswordHash)
               .IsRequired();

            });

            base.OnModelCreating(builder);
        }
    }
}
