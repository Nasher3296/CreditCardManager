using CreditCardManager.Models.Banks;
using CreditCardManager.Models.Cards;
using CreditCardManager.Models.Movement;
using CreditCardManager.Models.Payers;
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
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Payer> Payers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movement>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Card).WithMany().OnDelete(DeleteBehavior.SetNull);
                entity.Property(e => e.Amount).HasColumnType("decimal(18,2)").IsRequired();
                entity.Property(e => e.InstallmentsQty).IsRequired();
                entity.Property(e => e.Date).IsRequired();
            });

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Card>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Alias).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Company).HasMaxLength(50);
                entity.HasOne(e => e.Bank)
                  .WithMany()
                  .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
            });
        }
    }
}
