namespace Play.DB.Repository
{
    public interface IGameRepository
    {
        void CreateGame(string gameType, GameAccount gameAcc1, GameAccount gameAcc2, int rating, bool result);
        List<Game> ReadGames();
        Game GetGameById(int gameID);
        void UpdateGame(Game game);
        void DeleteGame(Game game);
        void PrintGames();
        void PrintGames(GameAccount gameAccount);
        GameAccount ReadGameAccountByName(string username);
    }
}