using Play.DB.Repository;
using Play.DB.Service;
using Play.DB;
class Program
{
    static void Main()
    {
        DbContext dbContext = new DbContext();
        GameRepository gameRepository = new GameRepository(dbContext);
        GameAccountRepository gameAccountRepository = new GameAccountRepository(dbContext);
        GameAccountService gameAccountService = new GameAccountService(gameAccountRepository);
        GameService gameService = new GameService(gameRepository);

        try
        {
            gameAccountService.CreateGameAccount("standard","Nazar", 200);
            gameAccountService.CreateGameAccount("easy", "Andrii", 250);
            gameAccountService.CreateGameAccount("streak", "Maksym", 300);

            gameService.CreateGame("Nazar", 20, true);

            gameService.CreateGame("standard", "Maksym", "Nazar", 50, true);

            gameService.CreateGame("training", "Andrii", "Maksym", 120, true);

            gameAccountService.PrintAllGameAccounts();

            gameService.PrintGames();

            var Naz = gameRepository.ReadGameAccountByName("Nazar");
            var Andr = gameRepository.ReadGameAccountByName("Andrii");
            var Max = gameRepository.ReadGameAccountByName("Maksym");

            gameService.PrintGames(Naz);
            gameService.PrintGames(Andr);
            gameService.PrintGames(Max);


        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error: {ex.Message}");
        }

    }
}