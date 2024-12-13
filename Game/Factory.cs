using Play.Types;

namespace Play
{
    class GameFactory
    {
        public static Game CreateGame(string gameType, string user, string opponent, int rating, string result)
        {
            return gameType.ToLower() switch
            {
                "standard" => new StandardGame(user, opponent, rating, result),
                "training" => new TrainingGame(user, opponent, rating, result),
                "bot" => new BotGame(user, rating, result),
                _ => throw new ArgumentException("Invalid game type"),
            };
        }

    }
}