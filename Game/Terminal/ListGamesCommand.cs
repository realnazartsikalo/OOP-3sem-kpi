using Play.DB.Repository;
using Play.DB.Service;

namespace Play.Terminal
{
    public class ListGamesCommand : ICommand
    {
        private readonly IGameService gameService;

        public ListGamesCommand(IGameService gameService)
        {
            this.gameService = gameService;
        }

        public void Execute()
        {
            gameService.PrintAllGames();
        }
    }
}
