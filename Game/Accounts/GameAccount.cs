namespace Play
{
 public abstract class GameAccount
    {
        public abstract string AccountType {get; protected set;}
        public string UserName { get; set; }
        private int _currentRating;
        public int CurrentRating
        {
            get => _currentRating;
            set
            {
                 _currentRating = (value > 1) ? value : 1;
            }
        }
        public List<int> gamesHistory = new();

        protected virtual void GameRating(bool result, Game game)
        {
            int calculatedRating = game.CalculateRating();
            if (result)
            {
                CurrentRating += calculatedRating;
            }
            else
            {
                CurrentRating -= calculatedRating;
            }
        }
        public GameAccount(string userName, int initialRating = 100)
        {
            UserName = userName;
            CurrentRating = initialRating;
        }

        public void WinGame(Game game)
        {
            GameRating(true, game);
            gamesHistory.Add(game.ID);
        }

        public void LoseGame(Game game)
        {
            GameRating(false, game);
            gamesHistory.Add(game.ID);
        }      
    }
}