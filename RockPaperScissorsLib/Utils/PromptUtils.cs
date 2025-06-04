using RockPaperScissorsLib.Enums;

namespace RockPaperScissorsLib.Utils;

public static class PromptUtils
{
    public static Choice PromptForChoice()
    {
        while (true)
        {
            Console.Write("Enter choice: (R)ock, (P)aper, (S)cissors: ");
            string? input = Console.ReadLine()!.ToUpper();

            if (input is null)
                Console.WriteLine("No choice made, try again!");

            if (input == "R")
                return Choice.Rock;
            else if (input == "P")
                return Choice.Paper;
            else if (input == "S")
                return Choice.Scissors;
            else
                Console.WriteLine("Invalid choice, try again!");
        }
    }
}
