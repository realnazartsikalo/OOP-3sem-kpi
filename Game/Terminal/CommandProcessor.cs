using Play.DB.Service;
using Play.Terminal;

public class CommandProcessor
{
    private readonly Dictionary<string, ICommand> commands;
    private readonly IGameAccountService gameAccountService; 
    private readonly IGameService gameService;
    public CommandProcessor(IGameAccountService gameAccountService, IGameService gameService)
    {
        this.gameAccountService = gameAccountService;

        commands = new Dictionary<string, ICommand>
        {
            { "show_players", new ShowPlayersCommand(gameAccountService) },
            { "add_player", new AddPlayerCommand(gameAccountService) },
            { "player_stats", new PlayerStatsCommand(gameService) },
            { "play_game", new PlayGameCommand(gameService) },
            { "help", new HelpCommand() },
            { "exit", new ExitCommand() },
            { "list_games", new ListGamesCommand(gameService) }
        };
        this.gameService = gameService;
    }

    public void ProcessCommand(string command)
    {
        if (commands.TryGetValue(command, out var commandObject))
        {
            commandObject.Execute();
        }
        else
        {
            Console.WriteLine("Invalid command. Enter 'help' for a list of available commands.");
        }
    }
}
