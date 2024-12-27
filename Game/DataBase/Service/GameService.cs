using Play.DB.Repository;

namespace Play.DB.Service
{
    public class GameService : IGameService
    {
        private readonly IGameRepository gameRepository;    

        public GameService(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }
        public void CreateGame(string player,int rating, bool result)
        {
            var Player = gameRepository.ReadGameAccountByName(player);
            gameRepository.CreateGame("bot", Player, null, rating, result);
        }
        public void CreateGame(string gameType, string player, string opponent, int rating, bool result)
        {
            if (player == opponent) throw new ArgumentException("You can not play with yourself");
            if (gameType != "bot")
            {
                var User1 = gameRepository.ReadGameAccountByName(player);
                var User2 = gameRepository.ReadGameAccountByName(opponent);
                gameRepository.CreateGame(gameType, User1, User2, rating, result);
            }
            else
            {
                CreateGame(player, rating, result);
            }

        }
        public void  PrintGames()
        {
            gameRepository.PrintGames();
        }
        public void PrintGames(GameAccount gameAccount)
        {
            gameRepository.PrintGames(gameAccount);
        }
        public void UpdateGames(Game game)
        {
            gameRepository.UpdateGame(game);
        }
        public void DeleteGame(Game game)
        {
            gameRepository.DeleteGame(game);
        }
        public GameAccount GetGameAccountByName(string userName)
        {
            return gameRepository.ReadGameAccountByName(userName);
        }
    }
}