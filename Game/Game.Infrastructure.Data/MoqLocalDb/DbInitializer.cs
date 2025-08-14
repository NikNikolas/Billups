using Game.Domain.Data.Abstractions.Entities.GameRpsls;
using Microsoft.EntityFrameworkCore;

namespace Game.Infrastructure.Data.MoqLocalDb
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<Choice>().HasData(
                new Choice
                {
                    Id = 1,
                    Name = "Rock"
                },
                new Choice
                {
                    Id = 2,
                    Name = "Paper"
                },
                new Choice
                {
                    Id = 3,
                    Name = "Scissors"
                },
                new Choice
                {
                    Id = 4,
                    Name = "Lizard"
                },
                new Choice
                {
                    Id = 5,
                    Name = "Spock"
                }
            );
        }
    }
}
