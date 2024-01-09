namespace Sloth_Machine_Project
{
    public static class UIMethods
    {
        /// <summary>
        /// Shows welcome to the game message
        /// </summary>

        public static void ShowWelcomeToTheGame()
        {
            Console.WriteLine("Welcome to the game\n");
        }

        /// <summary>
        /// Shows the game instruction to the user
        /// </summary>
        public static void ShowGameDescription()
        {
            Console.WriteLine("There are three horizontal and three vertical lines available to bet on." +
                           "You can make a bet for one line or more. A bet for one line costs $1." +
                           "The amount you bet either increases or reduces depending whether you win or lose." +
                           "The game ends after three betting attempts or if your bet amount is depleted before" +
                           "the third attempt.");
        }

        /// <summary>
        /// Shows the betting lines instruction to the user
        /// </summary>
        public static void ShowBettingLinesInstruction()
        {
            Console.WriteLine();
            Console.WriteLine("***************************************");
            Console.WriteLine();
            Console.WriteLine("Please enter 'A' to bet all the lines OR 'H' " +
                "to bet horizontal lines only or 'V' to bet vertical lines only or 'D'" +
                " to bet diagonal lines only. $1 per line.");
            Console.WriteLine();
        }

        /// <summary>
        /// Gets the response of the user whether to bet or not
        /// </summary>
        /// <returns>the betting choice of the user</returns>
        public static char GetBettingLinesResponse()
        {
            char betLineChoice = Console.ReadKey().KeyChar;
            return betLineChoice;
        }

        /// <summary>
        /// Prints the winning message to the user
        /// </summary>
        /// <param name="amount"></param>
        public static void PrintBetAmountIncrease(double amount)
        {
            UIMethods.WriteEmptyLine();
            Console.WriteLine("You have produced at least a winning row combination");
            Console.WriteLine($"Your bet amount has increased to: ${amount}");
        }

        /// <summary>
        /// Prints the losing message to the user
        /// </summary>
        /// <param name="amount"></param>
        public static void PrintBetAmountDecrease(double amount)
        {
            UIMethods.WriteEmptyLine();
            Console.WriteLine("You have not produced a winning row combination");
            Console.WriteLine($"Your bet amount has reduced to: ${amount}");
        }


        //public static void PrintBetAmountDecrease(double originalBet, double newBetAmount)
        //{

        //    if (newBetAmount > originalBet)
        //    {
        //        UIMethods.WriteEmptyLine();
        //        Console.WriteLine("You have not produced a winning row combination");
        //        Console.WriteLine($"Your bet amount has reduced to: ${newBetAmount}");
        //        //result = lineMatchingCount;
        //        //UIMethods.PrintBetAmountIncrease(benk);
        //    }
        //    else if (newBetAmount < originalBet)
        //    {
        //        UIMethods.WriteEmptyLine();
        //        Console.WriteLine("You have not produced a winning row combination");
        //        Console.WriteLine($"Your bet amount has reduced to: ${newBetAmount}");
        //        //result = -Constants.LINE_MATCH_COUNTER;
        //        //UIMethods.PrintBetAmountDecrease(result);
        //    }


        //}

        /// <summary>
        /// Prints a 2D arrays of numbers for betting
        /// </summary>
        /// <param name="arrayDisplay"></param>
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

        /// <summary>
        /// Creates a new line space for code clarity
        /// </summary>
        public static void WriteEmptyLine()
        {
            Console.WriteLine();
        }

        /// <summary>
        /// Obtains user betting decision input
        /// </summary>
        /// <returns>user bet decision</returns>
        public static bool MakeBetDecision()
        {
            Console.WriteLine("Enter '1' to make a bet, or '0' to quit.");
            int betDecision = int.Parse(Console.ReadLine());
            UIMethods.WriteEmptyLine();
            return (betDecision == Constants.BET_DECISION_YES);
        }

        /// <summary>
        /// Obtains user input on whether to make more bets
        /// </summary>
        /// <returns>user decision to bet more or not</returns>
        public static bool MakeAnotherBet()
        {
            Console.WriteLine("*********************************************");
            Console.WriteLine("Enter '1' to make another bet, or '0' to quit the game.");
            int newBet = int.Parse(Console.ReadLine());
            UIMethods.WriteEmptyLine();
            return (newBet == Constants.BET_DECISION_YES);
        }

        /// <summary>
        /// Obtains the amount the user wishes to bet to play the game
        /// </summary>
        /// <returns>the amount</returns>
        public static double GetBetAmount()
        {
            Console.WriteLine("Please enter the dollar amount you want to bet\n");
            double amountToBet = double.Parse(Console.ReadLine());
            return amountToBet;
        }

    }
}
