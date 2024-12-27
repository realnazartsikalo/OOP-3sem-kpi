using Play.DB.Service;

namespace Play.Terminal
{
    public class PlayGameCommand : ICommand
    {
        private readonly IGameService gameService;

        public PlayGameCommand(IGameService gameService)
        {
            this.gameService = gameService;
        }

        public void Execute()
        {
            Console.Write("Enter the name of Player 1: ");
            string player1 = Console.ReadLine();

            Console.Write("Enter the name of Player 2 (or leave blank for BOT): ");
            string player2 = Console.ReadLine();
            
            bool result = new Random().Next(2) == 0;

            if (!string.IsNullOrWhiteSpace(player2)) 
            {
                Console.Write("Enter the game type (standard/training): ");
                string gameType = Console.ReadLine().Trim().ToLower();
                Console.Write("Enter the rating: ");
                int rating;
                while (!int.TryParse(Console.ReadLine(), out rating))
                {
                    Console.WriteLine("Invalid rating. Please enter a valid integer.");
                }
                gameService.CreateGame(gameType, player1, player2, rating, result);
                Console.WriteLine($"Game played between {player1} and {player2} with rating {rating}. Result: {(result? $"{player1} wins!" : $"{player2} wins!")} ");
            }
            else {
                string gameType = "bot";
                Console.Write("Enter the rating: ");
                int rating;
                while (!int.TryParse(Console.ReadLine(), out rating))
                {
                    Console.WriteLine("Invalid rating. Please enter a valid integer.");
                }
                gameService.CreateGame(player1, rating, result);
                Console.WriteLine($"Game played between {player1} and BOT with rating {rating}. Result: {(result? $"{player1} wins!" : $"BOT wins!")} ");
            }
        }
    }
}