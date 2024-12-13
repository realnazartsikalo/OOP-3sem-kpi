  abstract class Game
    {
       

        public int ID { get; set; }
        public string User { get; }
        public string Opponent { get; }
        public int Rating { get; }
        public int NewRating { get; set; }
        public string GameResult { get; }
        public string? GameType { get; protected set; } 
        public static int lastAssignedId = 0;
        public abstract int CalculateRating();
        public Game(string user, string opponent, int rating, string result)
        {
            User = user;
            Opponent = opponent;
            Rating = rating;
            GameResult = result;
        }
        
    }
