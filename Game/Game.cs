using System;

namespace Game
{
    public class Game
    {
       

        public int ID { get; }
        public string User { get; }
        public string Opponent { get; }
        public int Rating { get; }
        public int NewRating { get; }
        public string GameResult { get; }
        
        private static int lastAssignedId = 1;
        public Game(string user, string opponent, int rating, int newRating, string result)
        {
            ID = lastAssignedId++; 
            User = user;
            Opponent = opponent;
            Rating = rating;
            NewRating = newRating;
            GameResult = result;
        }
    }

}