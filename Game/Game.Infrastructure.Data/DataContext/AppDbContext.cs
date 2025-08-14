using Game.Domain.Data.Abstractions.Entities.GameRpsls;
using Game.Infrastructure.Data.MoqLocalDb;
using Microsoft.EntityFrameworkCore;

namespace Game.Infrastructure.Data.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Choice> Choices { get; set; }
        public DbSet<GameResultHistory> GameResultHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new DbInitializer(modelBuilder).Seed();
        }
    }
}
