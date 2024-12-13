namespace Play.Types
{
    class BotGame: Game
    {
        public override int  CalculateRating()
        {
            return Rating / 2;
        }
        public BotGame(string user, int rating, string result) : base(user,"BOT", rating, result)
        {
            GameType = "VS bot";
        }
    }
}