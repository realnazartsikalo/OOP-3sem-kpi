using Play.DB.Service;

namespace Play.Terminal
{
    public class AddPlayerCommand : ICommand
    {
        private readonly IGameAccountService gameAccountService;

        public AddPlayerCommand(IGameAccountService gameAccountService)
        {
            this.gameAccountService = gameAccountService;
        }

        public void Execute()
        {
            Console.Write("Enter the name of the player: ");
            string playerName = Console.ReadLine();

            Console.Write("Enter the account type (standard/easy/streak): ");
            string accountType = Console.ReadLine();

            Console.Write("Enter the initial rating: ");
            int initialRating;
            while (!int.TryParse(Console.ReadLine(), out initialRating))
            {
                Console.WriteLine("Invalid rating. Please enter a valid integer.");
            }

            gameAccountService.CreateGameAccount(accountType, playerName, initialRating);
            Console.WriteLine($"Player {playerName} added successfully.");
        }
    }

}
