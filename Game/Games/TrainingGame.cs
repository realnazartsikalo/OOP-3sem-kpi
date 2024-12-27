namespace Play.Types
{
     class TrainingGame: Game
    {
        public override int CalculateRating()
        {
            return 0;
        }
        public TrainingGame(string user, string opponent, int rating, bool result) : base(user, opponent, rating, result)
        {
            GameType = "Non-rating";
        }
    }
}