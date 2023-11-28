using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Sloth_Machine_Project
{
    public static class UIMethods
    {
        const int BET_DECISION_YES = 1;
        const int MIN_BET_AMOUNT = 1;

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

        public static char BettingLinesResponse()
        {
            char betLineChoice = Console.ReadKey().KeyChar; 
            return betLineChoice;
        }

        public static void PrintBetAmountIncrease(double amount)
        {
            UIMethods.WriteEmptyLine();
            Console.WriteLine("You have produced at least a winning row combination");
            Console.WriteLine($"Your bet amount has increased to: ${amount}");
        }

        public static void PrintBetAmountDecrease(double amount)
        {
            UIMethods.WriteEmptyLine();
            Console.WriteLine("You have not produced a winning row combination");
            Console.WriteLine($"Your bet amount has reduced to: ${amount}");
        }

        public static void Print2DArray(int[,] arrayDisplay)
        {

            for (int rowNumbers = 0; rowNumbers < 3; rowNumbers++)
            {
                for (int columnNumbers = 0; columnNumbers < 3; columnNumbers++)
                {
                    Console.Write($"{arrayDisplay[rowNumbers, columnNumbers] + "\t"}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void WriteEmptyLine()
        {
            Console.WriteLine();
        }

        public static bool MakeBetDecision()
        {
            Console.WriteLine("Enter '1' to make a bet, or '0' to quit.");
            int betDecision = int.Parse(Console.ReadLine());
            UIMethods.WriteEmptyLine();
            return (betDecision == BET_DECISION_YES);
        }

        public static bool MakeAnotherBet()
        {
            Console.WriteLine("*********************************************");
            Console.WriteLine("Enter '1' to make another bet, or '0' to quit the game.");
            int newBet = int.Parse(Console.ReadLine());
            UIMethods.WriteEmptyLine();
            return (newBet == BET_DECISION_YES);
        }

        public static double GetBetAmount()
        {
            Console.WriteLine("Please enter the dollar amount you want to bet\n");
            double amountToBet = double.Parse(Console.ReadLine());
            return amountToBet;
        }

    }
}
