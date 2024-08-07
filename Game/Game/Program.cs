internal class Program
{

    public enum enGameChoice
    {
        Stone = 1,
        Paper = 2,
        Scissor = 3,
    }

    public enum enWinner
    {
        Player1 = 1,
        Computer = 2,
        Draw = 3,
    }

    public struct StRoundInfo
    {
        public short RoundNumber;
        public enGameChoice Player1Choice;
        public enGameChoice ComputerChoice;
        public enWinner Winner;
        public string winnerName;

    }

    public struct StGameResult
    {
        public short GameRounds;
        public short Player1WinTimes;
        public short ComputerWinTimes;
        public short DrawTimes;
        public enWinner GameWinner;
        public string GameWinnerName;
    }

    static enGameChoice ReadChoice(short Choice)
    {
        switch (Choice)
        {
            case 1: return enGameChoice.Stone;

            case 2: return enGameChoice.Paper;

            default: return enGameChoice.Scissor;
        }
    }

    static short RandomNumber(int from, int to)
    {
        Random random = new Random();
        return (short)(random.Next(from, to));
    }

    static enGameChoice enGetComputerChoice()
    {
        return (enGameChoice)RandomNumber(1, 4);
    }

    static void ReadScreen(short resalt)
    {
        switch (resalt)
        {
            case 0:
                Console.ForegroundColor = ConsoleColor.Green;
                break;
            case 1:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\a");
                break;
            case 2:
                Console.ForegroundColor = ConsoleColor.White;
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
        }
    }

    static enWinner WhoWonTheRound(StRoundInfo RoundInfo)
    {

        if (RoundInfo.Player1Choice == RoundInfo.ComputerChoice)
        {
            ReadScreen(3);
            return enWinner.Draw;
        }
        else if (RoundInfo.Player1Choice == enGameChoice.Stone && RoundInfo.ComputerChoice == enGameChoice.Scissor ||
                 RoundInfo.Player1Choice == enGameChoice.Scissor && RoundInfo.ComputerChoice == enGameChoice.Paper ||
                 RoundInfo.Player1Choice == enGameChoice.Paper && RoundInfo.ComputerChoice == enGameChoice.Stone
                 )
        {
            ReadScreen(0);
            return enWinner.Player1;
        }
        else
        {
            ReadScreen(1);
            return enWinner.Computer;
        }
    }

    static string WinnerName(enWinner Winner)
    {
        string[] arrWinnerNames = ["Player1", "Computer", "No Winner"];
        return arrWinnerNames[(int)Winner - 1];
    }

    static string ChoiceName(enGameChoice enGameChoice)
    {
        string[] arrGameChoice = ["Stone", "Paper", "Scissors"];
        return arrGameChoice[(int)enGameChoice - 1];
    }

    static short ReadNumber(string Message)
    {
        short num;
        Console.Write(Message + "\t");
        return num = short.Parse(Console.ReadLine());
    }

    static void PrintResult(StRoundInfo stRoundInfo)
    {
        Console.WriteLine($"\n__________Round [{stRoundInfo.RoundNumber}]__________\n\n" +
      $"Player1 Choice: {ChoiceName(stRoundInfo.Player1Choice)}" +
      $"\nComputer Choice: {ChoiceName(stRoundInfo.ComputerChoice)}" +
      $"\nRound Winner: {stRoundInfo.winnerName}" +
      $"\n_____________________________"
      );
    }

    static string Tabs(short HowManyTabs)
    {
        string t = "";
        for (int i = 0; i < HowManyTabs; i++)
        {
            t += "\t";
            Console.Write(t);
        }
        return t;
    }

    static string GameStatus(StGameResult stGameResult)
    {
        switch (stGameResult.GameWinner)
        {
            case enWinner.Player1:
                return "Good Game (^0^)";

            case enWinner.Computer:
                return "\aGame Over (-_-)";

            default:
                return "Draw (0_0)";
        }
    }

    static void PrintFinal(StGameResult stGameResult)
    {
        Console.WriteLine(
            $"\n{Tabs(2)}--------------------------------------------------\n" +
            $"{Tabs(1)}                    |+| {GameStatus(stGameResult)} |+|\n" +
            $"{Tabs(2)}--------------------------------------------------\n" +
            $"{Tabs(2)}-------------------- [ Game Result ] -------------\n" +
            $"{Tabs(2)}Game Rounds        : {stGameResult.GameRounds}\n" +
            $"{Tabs(2)}Player1 Won Times  : {stGameResult.Player1WinTimes}\n" +
            $"{Tabs(2)}Computer Won Times : {stGameResult.ComputerWinTimes}\n" +
            $"{Tabs(2)}Draw Times         : {stGameResult.DrawTimes}\n" +
            $"{Tabs(2)}Final Winner       : {stGameResult.GameWinnerName}\n" +
            $"{Tabs(2)}--------------------------------------------------\n");
        ReadScreen(2);

    }

    static StGameResult FillGameResult(short GameRounds, short Player1WinTimes, short ComputerWinTimes, short DrawTimes)
    {
        StGameResult stGameResult;

        stGameResult.GameRounds = GameRounds;
        stGameResult.Player1WinTimes = Player1WinTimes;
        stGameResult.ComputerWinTimes = ComputerWinTimes;
        stGameResult.DrawTimes = DrawTimes;
        stGameResult.GameWinner = WhoWinTheGame(Player1WinTimes, ComputerWinTimes);
        stGameResult.GameWinnerName = WinnerName(stGameResult.GameWinner);

        return stGameResult;
    }

    static enWinner WhoWinTheGame(short Player1WonTimes, short ComputerWonTimes)
    {
        if (Player1WonTimes == ComputerWonTimes)
        {
            ReadScreen(3);
            return enWinner.Draw;
        }
        else if (Player1WonTimes > ComputerWonTimes)
        {
            ReadScreen(0);
            return enWinner.Player1;
        }
        else
        {
            ReadScreen(1);
            return enWinner.Computer;
        }
    }

    static enGameChoice ReadPlayerChoice()
    {
        short Choice;
        do
        {
            Console.WriteLine("Your Choice : [1]:Stone ,[2]:Paper ,[3]:Scissors ...");
            Choice = short.Parse(Console.ReadLine());

        } while (Choice < 1 || Choice > 3);

        return (enGameChoice)Choice;
    }

    static StGameResult PlayGame(short Rounds)
    {
        short Player1WinnerTimes = 0, ComputerWinnerTimes = 0, DrawTimes = 0;

        StRoundInfo stRoundInfo = new StRoundInfo();

        for (short Round = 1; Round <= Rounds; Round++)
        {
            Console.WriteLine($"\nRound [{Round}] begins : ");

            stRoundInfo.RoundNumber = Round;
            stRoundInfo.Player1Choice = ReadPlayerChoice();
            stRoundInfo.ComputerChoice = enGetComputerChoice();
            stRoundInfo.Winner = WhoWonTheRound(stRoundInfo);
            stRoundInfo.winnerName = WinnerName(stRoundInfo.Winner);

            //increase win/draw counters
            if (stRoundInfo.Winner == enWinner.Player1) Player1WinnerTimes++;
            else if (stRoundInfo.Winner == enWinner.Computer) ComputerWinnerTimes++;
            else DrawTimes++;

            PrintResult(stRoundInfo);
            ReadScreen(2);
        }
        return FillGameResult(Rounds, Player1WinnerTimes, ComputerWinnerTimes, DrawTimes);
    }

    static short ReadHowManyRounds()
    {
        short GameRounds;
        do
        {
            GameRounds = ReadNumber("How Many Rounds 1 to 10 ?");
        } while (GameRounds < 1 || GameRounds > 10);

        return GameRounds;
    }

    static void StartGame()
    {
        ReadScreen(2);
        char again;
        do
        {
            StGameResult stGameResult = PlayGame(ReadHowManyRounds());
            PrintFinal(stGameResult);

            Console.Write("Do you want to play again ? Y/N");
            again = char.Parse(Console.ReadLine().ToLower());
            Console.Clear();

        } while (again != 'n');

        Console.WriteLine("Good Bye (^_^)");
    }


    private static void Main(string[] args)
    {
        StartGame();
    }
}