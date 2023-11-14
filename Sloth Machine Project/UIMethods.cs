using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sloth_Machine_Project
{
    public static class UIMethods
    {
        public static void ShowWelcomeToTheGame()
        {
            Console.WriteLine("Welcome to the game\n");
        }

        public static void ShowGameDescription()
        {
            Console.WriteLine("There are three horizontal and three vertical lines available to bet on." +
                           "You can make a bet for one line or more. A bet for one line costs $1." +
                           "The amount you bet either increases or reduces depending whether you win or lose." +
                           "The game ends after three betting attempts or if your bet amount is depleted before" +
                           "the third attempt.");
        }

        public static void BettingLinesInstruction()
        {
            Console.WriteLine();
            Console.WriteLine("***************************************");
            Console.WriteLine();
            Console.WriteLine("Please enter 'A' to bet all the lines OR 'H' " +
                "to bet horizontal lines only or 'V' to bet vertical lines only or 'D'" +
                " to bet diagonal lines only. $1 per line.");
            Console.WriteLine();
        }

        public static string BettingLinesResponse()
        {
            string betLineChoice = Console.ReadLine().ToUpper();
            return betLineChoice;
        }

        public static void PrintBetAmountIncrease(double amount)
        {
            Console.WriteLine("You have produced at least a winning row combination");
            Console.WriteLine($"Your bet amount has increased to: ${amount}");
        }

        public static void PrintBetAmountDecrease(double amount)
        {
            Console.WriteLine("You have not produced a winning row combination");
            Console.WriteLine($"Your bet amount has reduced to: ${amount}");
        }

        public static void Print2DArray(int[,] arrayDisplay)
        {

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine($"{arrayDisplay}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void WriteEmptyLine()
        {
            Console.WriteLine();
        }
    }
}
