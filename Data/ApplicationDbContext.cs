using CreditCardManager.Models.Movement;
using Microsoft.EntityFrameworkCore;

namespace CreditCardManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<Movement> Movements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movement>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Card).IsRequired().HasMaxLength(16);
                entity.Property(e => e.Amount).HasColumnType("decimal(18,2)").IsRequired();
                entity.Property(e => e.InstallmentsQty).IsRequired();
                entity.Property(e => e.Date).IsRequired();
            });
        }
    }
}
