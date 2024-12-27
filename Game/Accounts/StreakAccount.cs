namespace Play.Accounts
{
     class StreakAccount : GameAccount
    {
        private int winningStreak = 0;

        public StreakAccount(string userName, int initialRating = 100) : base(userName, initialRating)
        {
        }
        public override string AccountType { get; protected set; } = "Streak";
        protected override void GameRating(bool result, Game game)
        {
            int calculatedRating = game.CalculateRating();
            if (result)
            {
                CurrentRating += calculatedRating * ++winningStreak; 
            }
            else
            {
                CurrentRating -= calculatedRating;
                winningStreak=0;
            }
        }
    }
}