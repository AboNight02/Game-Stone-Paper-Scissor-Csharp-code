internal class Program
{

    enum enGameType
    {
        Stone = 1,
        Paper = 2,
        Scissor = 3,
    }

    static void ReadScreen(int resalt)
    {
        switch (resalt)
        {
            case 0:
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 1:
                break;
            default:
                break;
        }
    }


    static void StartGame() { }


    private static void Main(string[] args)
    {
        Console.BackgroundColor = ConsoleColor.Green;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("hi");
    }
}