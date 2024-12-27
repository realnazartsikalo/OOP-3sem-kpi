namespace Play.Terminal
{
    public class ExitCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Exiting the program. Goodbye!");
            Environment.Exit(0);
        }
    }
}
