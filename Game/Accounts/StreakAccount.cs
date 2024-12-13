using System;

namespace Play.Accounts
{
     class StreakAccount : GameAccount
    {
        private int winningStreak = 0;

        public StreakAccount(string userName, int initialRating = 100) : base(userName, initialRating)
        {
        }

        protected override void GameRating(bool result, Game game)
        {
            int calculatedRating = game.CalculateRating();
            if (result)
            {
                CurrentRating += calculatedRating * winningStreak++; 
            }
            else
            {
                CurrentRating -= calculatedRating;
                winningStreak=0;
            }
        }
    }
}