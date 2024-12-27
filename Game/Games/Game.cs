  public abstract class Game
    {
        public int ID { get; set; }
        public string User1 { get; }
        public string User2 { get; }
        public int Rating { get; }
        public bool GameResult { get; }
        public string? GameType { get; protected set; } 
        public static int lastAssignedId = 1;
        public abstract int CalculateRating();
        public Game(string user1, string user2, int rating, bool result)
        {
            User1 = user1;
            User2 = user2;
            Rating = rating;
            GameResult = result;
            ID = lastAssignedId++;
        }
        
    }
