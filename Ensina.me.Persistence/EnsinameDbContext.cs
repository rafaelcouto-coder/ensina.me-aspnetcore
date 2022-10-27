using Ensina.me.Domain.Common;
using Ensina.me.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ensina.me.Persistence
{
    public class EnsinameDbContext : DbContext
    {
        public EnsinameDbContext(DbContextOptions<EnsinameDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EnsinameDbContext).Assembly);

            //seed data
            var User1Guid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var User2Guid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");

            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = User1Guid,
                Username = "rafa",
                FirstName = "rafael",
                LastName = "couto",
                Email = "rafael@teste.com",
                Password = "12345",
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = User2Guid,
                Username = "bia",
                FirstName = "bianca",
                LastName = "silva",
                Email = "bianca@teste.com",
                Password = "12345",
            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastUpdatedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
