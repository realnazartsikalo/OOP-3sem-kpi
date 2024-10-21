using Game;
class Program
{
    static void Main()
    {
        GameAccount Nazar = new GameAccount("Nazar", 10);
        GameAccount Andrii = new GameAccount("Andrii", 10);
        GameAccount Maksym = new GameAccount("Maksym", 10);
        GameAccount Yara = new GameAccount("Yara", 10);

        try
        {
            Nazar.GameResult(Andrii, true, 12);
            Nazar.GameResult(Maksym, false, 20);
            Nazar.GameResult(Yara, true, 15);

            Andrii.GameResult(Nazar, false, 12);
            Andrii.GameResult(Maksym, true, 20);

            Maksym.GameResult(Nazar, true, 22);
            Maksym.GameResult(Andrii, false, 22);

            Yara.GameResult(Nazar, false, 16);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        Nazar.GetStats();
        Andrii.GetStats();
        Maksym.GetStats();
        Yara.GetStats();
    }
}