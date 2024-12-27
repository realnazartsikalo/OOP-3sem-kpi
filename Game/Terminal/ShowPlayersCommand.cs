using Play.DB.Service;

namespace Play.Terminal
{
    public class ShowPlayersCommand : ICommand
    {
        private readonly IGameAccountService gameAccountService;

        public ShowPlayersCommand(IGameAccountService gameAccountService)
        {
            this.gameAccountService = gameAccountService;
        }

        public void Execute()
        {
            gameAccountService.PrintAllGameAccounts();
        }
    }
}
