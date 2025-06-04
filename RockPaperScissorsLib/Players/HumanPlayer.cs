using RockPaperScissorsLib.Enums;

namespace RockPaperScissorsLib.Players;

public class HumanPlayer : IPlayer
{
    public Choice GetChoice()
    {
        Choice choice;

        do
        {
            Console.Write("Enter choice: (R)ock, (P)aper, (S)cissors: ");
            string? input = Console.ReadLine()!.ToUpper();

            if (input is null)
                Console.WriteLine("No choice made, try again!");

            if (input == "R")
            {
                choice = Choice.Rock;
                break;
            }
            else if (input == "P")
            {
                choice = Choice.Paper;
                break;
            }
            else if (input == "S")
            {
                choice = Choice.Scissors;
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice, try again!");
            }
        } while (true);

        return choice;
    }
}
