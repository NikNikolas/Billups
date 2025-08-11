using Game.Domain.Data.Abstractions.Entities.GameRpsls;

namespace Game.Infrastructure.Data.MoqLocalDb
{
    /// <summary>
    /// Mock class simulates local Db instance. Initially populated with data
    /// </summary>
    internal class LocalDb
    {
        public static LocalDb Current { get; } = new LocalDb();

        public IEnumerable<Choice> Choices { get; set; }
        public List<GameResultHistory> GameResultHistories { get; set; }

        public LocalDb()
        {
            GameResultHistories = new List<GameResultHistory>();

            Choices = new List<Choice>()
            {
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
            };
        }
    }
}
