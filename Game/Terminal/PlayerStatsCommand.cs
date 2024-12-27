using Play.DB.Service;

namespace Play.Terminal
{
    public class PlayerStatsCommand : ICommand
    {
        private readonly IGameService gameService;

        public PlayerStatsCommand(IGameService gameService)
        {
            this.gameService = gameService;
        }

        public void Execute()
        {
            Console.Write("Enter the name of the player: ");
            string playerName = Console.ReadLine();

            var player = gameService.GetGameAccountByName(playerName);

            if (player != null)
            {
                gameService.PrintGames(player);
            }
            else
            {
                Console.WriteLine($"Player {playerName} not found.");
            }
        }
    }
}
