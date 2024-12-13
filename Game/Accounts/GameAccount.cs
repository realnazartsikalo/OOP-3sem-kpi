using System;

namespace Play
{
 abstract class GameAccount
    {
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
        private List<Game> gamesHistory = new();

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
            game.NewRating = CurrentRating;
        }

        public void LoseGame(Game game)
        {
            GameRating(false, game);
            game.NewRating = CurrentRating;
        }
        
         public void GameResult(GameAccount opponent, bool result, int rating, string gameType)
        {
            if (this != opponent)
            {
                if (result)
                {
                    gamesHistory.Add(GameFactory.CreateGame(gameType, UserName, opponent.UserName, rating, "Win"));
                    opponent.gamesHistory.Add(GameFactory.CreateGame(gameType, opponent.UserName, UserName, rating, "Lost"));
                    WinGame(gamesHistory.Last());
                    opponent.LoseGame(opponent.gamesHistory.Last());
                }
                else
                {
                    gamesHistory.Add(GameFactory.CreateGame(gameType, UserName, opponent.UserName, rating, "Lost"));
                    opponent.gamesHistory.Add(GameFactory.CreateGame(gameType, opponent.UserName, UserName, rating, "Win"));
                    LoseGame(gamesHistory.Last());
                    opponent.WinGame(opponent.gamesHistory.Last());
                }

                gamesHistory.Last().ID = ++Game.lastAssignedId;
                opponent.gamesHistory.Last().ID = Game.lastAssignedId;
            }
            else
            {
                if (result)
                {
                    gamesHistory.Add(GameFactory.CreateGame("BOT", UserName, "", rating, "Win"));
                    WinGame(gamesHistory.Last());
                }
                else
                {
                    gamesHistory.Add(GameFactory.CreateGame("BOT", UserName, "", rating, "Lost"));
                    LoseGame(gamesHistory.Last());
                }
                gamesHistory.Last().ID = ++Game.lastAssignedId;
            }
        }


        public void GetStats()
        {
            Console.WriteLine($"Game history for {UserName}(Rating: {CurrentRating}):");

            Console.WriteLine("--------------------------------------------------------------------------------------------");
            Console.WriteLine("│      ID        │   User   │ Opponent │ Rating  │ Result │ Current Rating  │ Game type    |");
            Console.WriteLine("--------------------------------------------------------------------------------------------");

            for (int i = 0; i < gamesHistory.Count; i++)
            {
                Console.WriteLine($"│ {gamesHistory[i].ID,14} │ {gamesHistory[i].User,-8} │ {gamesHistory[i].Opponent,-8} │ {gamesHistory[i].Rating,7} │ {gamesHistory[i].GameResult,-6} │ {gamesHistory[i].NewRating,15} │ {gamesHistory[i].GameType, 12} |");
                Console.WriteLine("--------------------------------------------------------------------------------------------");
            }

           
            Console.WriteLine();
        }

    }
}