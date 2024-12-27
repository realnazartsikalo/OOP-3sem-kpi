using Play.Types;

namespace Play
{
    class GameFactory
    {
        public static Game CreateGame(string gameType, string user1, string user2, int rating, bool result)
        {
            return gameType.ToLower() switch
            {
                "standard" => new StandardGame(user1, user2, rating, result),
                "training" => new TrainingGame(user1, user2, rating, result),
                "bot" => new BotGame(user1, rating, result),
                _ => throw new ArgumentException("Invalid game type"),
            };
        }

    }
}