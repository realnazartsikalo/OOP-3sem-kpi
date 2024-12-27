namespace Play.DB.Repository
{

    public class GameRepository : IGameRepository
    {
        private readonly DbContext dbContext;

        public GameRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateGame(string gameType, GameAccount User1, GameAccount User2, int rating, bool result)
        {
            if (rating < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "Rating can't be less than 1");
            }

            var User2Name = User2 == null ? "BOT" : User2.UserName;
            var game = GameFactory.CreateGame(gameType, User1.UserName, User2Name, rating, result);

            dbContext.Games.Add(game);

            if (result)
            {
                User1.WinGame(game);
                User2?.LoseGame(game);
            }
            else
            {
                User1.LoseGame(game);
                User2?.WinGame(game);
            }
           
        }
        public GameAccount ReadGameAccountByName(string username)
        {
            return dbContext.GameAccounts.Find(a => a.UserName == username);
        }

        public List<Game> ReadGames()
        {
            return dbContext.Games;
        }

        public Game GetGameById(int GameID)
        {
            return dbContext.Games.Find(g => g.ID == GameID);

        }

        public void UpdateGame(Game game)
        {
            var index = dbContext.Games.IndexOf(game);
            dbContext.Games[index] = game;
        }
        public void DeleteGame(Game game)
        {
            dbContext.Games.Remove(game);

        }
        public void PrintGames()
        {
            Console.WriteLine("All games:");
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("| ID\t| Player 1\t| Player 2\t| Result\t| Rating\t| Game Type\t|");
            Console.WriteLine("-----------------------------------------------------------------------------------------");

            foreach (var game in dbContext.Games)
            {
                Console.WriteLine($"| {game.ID,-6}| {game.User1,-14}| {game.User2,-14}| {(game.GameResult ? $"{game.User1} Win" : $"{game.User2} Win"),-14}| {game.Rating,-14}| {game.GameType, -14}|");
            }

            Console.WriteLine("-----------------------------------------------------------------------------------------");
        }

        public void PrintGames(GameAccount gameAccount)
        {
            Console.WriteLine($"\nGames history of {gameAccount.UserName}");
            Console.WriteLine($"(Current rating: {gameAccount.CurrentRating})");
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("| Player 1\t| Player 2\t| Result\t| Rating\t| Game Type\t|");
            Console.WriteLine("---------------------------------------------------------------------------------");

            foreach (int i in gameAccount.gamesHistory)
            {
                var game = GetGameById(i);

                Console.WriteLine($"| {game.User1,-14}| {game.User2,-14}|  {(game.GameResult ? $"{game.User1} Win" : $"{game.User2} Win"),-13}| {game.Rating,-14}| {game.GameType, -14}|");
            }

            Console.WriteLine("---------------------------------------------------------------------------------");
        }
    }
}