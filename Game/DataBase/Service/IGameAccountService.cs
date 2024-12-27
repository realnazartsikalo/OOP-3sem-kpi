namespace Play.DB.Service
{
    public interface IGameAccountService
    {
        void CreateGameAccount(string gameType, string userName, int initialRating);
        List<GameAccount> GetGameAccounts();
        void PrintAllGameAccounts(); 
    }
}