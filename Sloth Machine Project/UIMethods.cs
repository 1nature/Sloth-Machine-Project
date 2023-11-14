using System;
using System.Collections.Generic;
using System.Linq;
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

        public static bool MakeBetDecision()
        {
            Console.WriteLine("Enter '1' to make a bet, or '0' to quit.");
            int betDecision = int.Parse(Console.ReadLine());
            UIMethods.WriteEmptyLine();
            return (betDecision == BET_DECISION_YES);
        }

        public static void MakeAnotherBet()
        {
            bool theBetDecision = UIMethods.MakeBetDecision();
            UIMethods.WriteEmptyLine();

            if (theBetDecision == false)
            {
                Console.WriteLine("You have decided to quit this game.");
            }

            if (theBetDecision == true)
            {
                UIMethods.WriteEmptyLine();
                bool valid = false;
                Console.WriteLine("Please enter the dollar amount you want to bet\n");
                double betAmount = double.Parse(Console.ReadLine());
                while (!valid)
                {
                    if (betAmount < MIN_BET_AMOUNT)
                    {
                        Console.WriteLine("Please enter a higher bet amount");
                        betAmount = double.Parse(Console.ReadLine());
                    }
                    else
                    {
                        valid = true;
                    }
                }

            }

        }

        public static double GetBetAmount()
        {
            Console.WriteLine("Please enter the dollar amount you want to bet\n");
            double amountToBet = double.Parse(Console.ReadLine());
            return amountToBet;
        }

    }
}
