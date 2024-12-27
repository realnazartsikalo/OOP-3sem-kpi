namespace Play.Terminal
{
    public class HelpCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("\nAvailable Commands:");
            Console.WriteLine("1. show_players - Display players from the database");
            Console.WriteLine("2. add_player - Add a new player");
            Console.WriteLine("3. player_stats - Display statistics for a specific player");
            Console.WriteLine("4. play_game - Play a game");
            Console.WriteLine("5. list_games - Shows all games that was played");      
            Console.WriteLine("6. help - Show available commands");
            Console.WriteLine("7. exit - Exit the program");
     
        }
    }
}
