namespace Play.DB.Repository
{
    public interface IGameAccountRepository
    {
        void CreateGameAccount(string accountType, string username, int initialRating);
        List<GameAccount> ReadGameAccounts();
     
        void UpdateGameAccount(GameAccount gameAccount);
        void DeleteGameAccount(GameAccount gameAccount);
    }
}
