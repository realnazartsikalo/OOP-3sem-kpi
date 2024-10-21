using System;

namespace Game
{
    class GameAccount
    {
        public string UserName { get; set; }
        public int CurrentRating { 
            get { return Rating; } 
            set { Rating = (value > 1) ? value : 1;} 
            }
        private int Rating = 1;
        public int GamesCount { get => gamesHistory.Count; }

        private List<Game> gamesHistory = new();
      
        public GameAccount(string userName, int initialRating = 100)
        {
            UserName = userName;
            CurrentRating =  initialRating;
        }

        public void WinGame(GameAccount opponent, int rating)
        {
            if (rating < 0)
                throw new ArgumentOutOfRangeException(nameof(rating), "Rating cannot be less than one.");
            CurrentRating += rating; 
            gamesHistory.Add(new Game(UserName, opponent.UserName, rating, CurrentRating, "Win"));
        }

        public void LoseGame(GameAccount opponent, int rating)
        {
            if (rating < 0)
                throw new ArgumentOutOfRangeException(nameof(rating), "Rating cannot be less than one.");
            CurrentRating -= rating;
            gamesHistory.Add(new Game(UserName, opponent.UserName, rating, CurrentRating, "Lost"));
        }

        public void GameResult(GameAccount opponent, bool result, int rating)
        {
            if (rating < 0)
                throw new ArgumentOutOfRangeException(nameof(rating), "Rating cannot be less than one.");
            
            if (this == opponent)
                throw new ArgumentException("Cannot play with yourself");

            if (result)
            {
                WinGame(opponent, rating);
                opponent.LoseGame(this, rating);
            }
            else
            {
                LoseGame(opponent, rating);
                opponent.WinGame(this, rating);
            }
        }

        public void GetStats()
        {
            Console.WriteLine($"Game history for {UserName}(Rating: {CurrentRating}):");

            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("│      ID        │   User   │ Opponent │ Rating  │ Result │ Current Rating  │");
            Console.WriteLine("-----------------------------------------------------------------------------");

            for (int i = 0; i < GamesCount; i++)
            {
                Console.WriteLine($"│ {gamesHistory[i].ID,14} │ {gamesHistory[i].User,-8} │ {gamesHistory[i].Opponent,-8} │ {gamesHistory[i].Rating,7} │ {gamesHistory[i].GameResult,-6} │ {gamesHistory[i].NewRating,15} │");
                Console.WriteLine("-----------------------------------------------------------------------------");
            }

           
            Console.WriteLine();
        }

    }
}