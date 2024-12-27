using Play.Accounts;

namespace Play
{
    class GameAccountFactory
    {
        public static GameAccount CreateGameAccount(string accountType, string username, int initialRating)
        {
            return accountType.ToLower() switch
            {
                "standard" => new StandardAccount(username, initialRating),
                "easy" => new EasyAccount(username, initialRating),
                "streak" => new StreakAccount(username, initialRating),
                _ => throw new ArgumentException($"Account type doesn't exist - {accountType}"),
            };
        }
    }
}
