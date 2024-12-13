using Play.Accounts;
class Program
{
    static void Main()
    {
        StandardAccount BazNazar = new StandardAccount("Nazar", 1000);
        StreakAccount StrAndrii = new StreakAccount("Andrii", 5);
        EasyAccount EasyMaksym = new EasyAccount("Maksym", 100);

        try
        {
            BazNazar.GameResult(StrAndrii, true, 10, "standard");
            BazNazar.GameResult(EasyMaksym, false, 20, "training");

            StrAndrii.GameResult(BazNazar, false, 30,"standard");
            StrAndrii.GameResult(EasyMaksym, true, 40, "training");

            EasyMaksym.GameResult(BazNazar, true, 50, "training");
            EasyMaksym.GameResult(StrAndrii, false, 60, "standard");

            StrAndrii.GameResult(StrAndrii, true, 30,"bot");
            StrAndrii.GameResult(StrAndrii, true, 30,"bot");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        BazNazar.GetStats();
        StrAndrii.GetStats();
        EasyMaksym.GetStats();
    }
}