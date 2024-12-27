using Play.DB.Repository;

namespace Play.DB.Service
{ 
   public class GameAccountService : IGameAccountService
    {
        private readonly IGameAccountRepository gameAccountRepository;

        public GameAccountService(IGameAccountRepository gameAccountRepository)
        {
            this.gameAccountRepository = gameAccountRepository;
        }

        public void CreateGameAccount(string accountType, string username, int initialRating)
        {
            gameAccountRepository.CreateGameAccount(accountType, username, initialRating);
        }
        
   
        public List<GameAccount> GetGameAccounts()
        {
            return gameAccountRepository.ReadGameAccounts();
        }

        public void PrintAllGameAccounts()
         {
            var accounts = GetGameAccounts()
                .OrderByDescending(account => account.CurrentRating) 
                .ToList();
            Console.WriteLine("List of all created game accounts:");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("| Username\t| Account Type\t| Rating\t|");
            Console.WriteLine("-------------------------------------------------");

            foreach (var account in accounts)
            {
                Console.WriteLine($"| {account.UserName,-13} | {account.AccountType,-13} | {account.CurrentRating,-13} | ");
            }

            Console.WriteLine("-------------------------------------------------");
          }
    }
}
