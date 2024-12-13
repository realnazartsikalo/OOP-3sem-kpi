namespace Play.Types
{
    class StandardGame : Game
    {
        public override int CalculateRating()
        {
            return Rating;
        }

        public StandardGame(string user, string opponent, int rating, string result): base(user, opponent, rating, result)
        {
            GameType = "Rating";
        }
    }
}