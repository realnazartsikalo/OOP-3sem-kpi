using System;

namespace Play.Accounts
{
     class EasyAccount : GameAccount
    {
        protected override void GameRating(bool result, Game game)
        {
            int calculatedRating = game.CalculateRating();
            if (result)
            {
                CurrentRating += calculatedRating*2;
            }
            else
            {
                CurrentRating -= calculatedRating/2;
            }
        }

        public EasyAccount(string userName, int initialRating=500) : base(userName, initialRating)
        {
       
        }
    }
}