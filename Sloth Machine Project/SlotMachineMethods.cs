using System.Diagnostics.Metrics;

namespace Sloth_Machine_Project
{
    public static class SlotMachineMethods
    {
        const int MIN_RAND_NUMBER = 0;
        const int MAX_RAND_NUMBER = 20;
        const int NUMBER_OF_ROWS = 3;
        const int NUMBER_OF_COLUMNS = 3;
        const int BET_DECISION_YES = 1;
        const int BET_DECISION_NO = 0;
        //const int LINE_MATCH_COUNTER = 1;
        const int MIN_BET_AMOUNT = 1;
        //const int MIN_ROWONLY_LOSS = 3;
        //const int MIN_COLUMNONLY_LOSS = 3;
        //const int MIN_DIAGONAL_LOSS = 2;

        public static readonly Random generator = new Random();
        public static void ShowWelcomeToTheGame()

        {
            Console.WriteLine("Welcome to the game\n");
        }

        public static int[,] GetRandom2DArray()
        {
            int[,] arrayNumbers = new int[NUMBER_OF_ROWS, NUMBER_OF_COLUMNS];

            for (int row = 0; row < arrayNumbers.GetLength(0); row++)
            {
                for (int column = 0; column < arrayNumbers.GetLength(1); column++)
                {
                    arrayNumbers[row, column] = generator.Next(MIN_RAND_NUMBER, MAX_RAND_NUMBER + 1);
                    Console.Write(arrayNumbers[row, column] + "\t"); //just for checks
                }
                Console.WriteLine();

            }
            Console.WriteLine();
            return arrayNumbers;
        }

        public static void ShowGameDescription()
        {
            Console.WriteLine("There are three horizontal and three vertical lines available to bet on." +
                           "You can make a bet for one line or more. A bet for one line costs $1." +
                           "The amount you bet either increases or reduces depending whether you win or lose." +
                           "The game ends after three betting attempts or if your bet amount is depleted before" +
                           "the third attempt");
        }

        public static bool MakeBetDecision()
        {
            Console.WriteLine("Enter '1' to make a bet, or '0' to quit");
            int betDecision = int.Parse(Console.ReadLine());
            Console.WriteLine();
            if (betDecision == BET_DECISION_YES)
            {
                return true;
            }

            else
            {
                return false;
                Console.WriteLine("You have decided not to make a bet");
            }
        }

        public static void MakeAnotherBet()
        {
            bool theBetDecision = SlotMachineMethods.MakeBetDecision();
            Console.WriteLine();

            if (theBetDecision == false)
            {
                Console.WriteLine("You have decided to quit this game.");
            }

            if (theBetDecision == true)
            {
                Console.WriteLine();
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

        public static void BettingLinesInstruction()
        {
            Console.WriteLine();
            Console.WriteLine("**************************************");
            Console.WriteLine();
            Console.WriteLine("Please enter 'A' to bet all the lines OR 'H' " +
                "to bet horizontal lines only or 'V' to bet vertical lines only or 'D'" +
                " to bet diagonal lines only. $1 per line");
            Console.WriteLine();
        }

        public static string BettingLinesResponse()
        {
            string betLineChoice = Console.ReadLine().ToUpper();
            return betLineChoice;
        }

        public static double GetBetAmount()
        {
            Console.WriteLine("Please enter the dollar amount you want to bet\n");
            double amountToBet = double.Parse(Console.ReadLine());
            return amountToBet;
        }

        public static int RowImplementation(int[,] slotArray)
        {
            //int[,] arrayCheck = new int[NUMBER_OF_ROWS, NUMBER_OF_COLUMNS];
            bool lineMatch = true;
            int horizontalRowCounter = 0;

            for (int rowIndex = 0; rowIndex < NUMBER_OF_ROWS; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < NUMBER_OF_COLUMNS; columnIndex++)
                {
                    //if (arrayCheck[rowIndex, 0] != arrayCheck[rowIndex, columnIndex])
                    //{
                    //    lineMatch = false;
                    //}
                    if (slotArray[rowIndex, 0] != slotArray[rowIndex, columnIndex])
                    {
                        lineMatch = false;
                    }
                }

                if (lineMatch)
                {
                    horizontalRowCounter++;
                }
            }
            return horizontalRowCounter;
        }

        public static int ColumnImplementation(int[,] slotArray)
        {
            //int[,] arrayCheck = new int[NUMBER_OF_ROWS, NUMBER_OF_COLUMNS];
            bool lineMatch = true;
            int verticalColumnCounter = 0;

            for (int rowIndex = 0; rowIndex < NUMBER_OF_ROWS; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < NUMBER_OF_COLUMNS; columnIndex++)
                {
                    //if (arrayCheck[columnIndex, 0] != arrayCheck[rowIndex, columnIndex])
                    //{
                    //    lineMatch = false;
                    //}

                    if (slotArray[columnIndex, 0] != slotArray[rowIndex, columnIndex])
                    {
                        lineMatch = false;
                    }
                }

                if (lineMatch)
                {
                    verticalColumnCounter++;
                }
            }
            return verticalColumnCounter;
        }

        public static double PromptABetAmountDecrease(double X)
        {
            return X;
        }



        public static double PromptBetAmountIncrease(double betAmountIn, double counter)
        {
            double result = betAmountIn + counter;
            Console.WriteLine("You have produced at least a winning row combination");
            Console.WriteLine($"Your row only bet amount has increased to: ${result}");
            return result;
        }

        //public static void GetLossComment()
        //{
        //    double whoKnows = PromptABetAmountDe
        //    Console.WriteLine("You have produced at least a winning row combination");
        //    Console.WriteLine($"Your row only bet amount has increased to: ${result}");
        //}

        public static double PromptBetAmountDecrease(double betAmountOut, double counter)
        {
            double result = betAmountOut - counter;
            Console.WriteLine("You have not produced a winning row combination");
            Console.WriteLine($"Your row only bet amount has reduced to: ${result}");
            return result;
        }

        public static int DiagonalImplementation(int[,] slotArray)
        {
            //int[,] arrayCheck = new int[NUMBER_OF_ROWS, NUMBER_OF_COLUMNS];
            bool lineMatch = true;
            int diagonalOneCounter = 0;
            int diagonalTwoCounter = 0;
            int diagonalLength = 3;

            for (int diagonalIndex = 0; diagonalIndex < diagonalLength; diagonalIndex++)
            {
                if (slotArray[diagonalIndex, diagonalIndex] != slotArray[diagonalIndex, diagonalIndex])
                {
                    lineMatch = false;
                }

                if (lineMatch)
                {
                    diagonalOneCounter++;
                }

                if (slotArray[diagonalIndex, 2 - diagonalIndex] != slotArray[diagonalIndex, 2 - diagonalIndex])
                {
                    lineMatch = false;
                }

                if (lineMatch)
                {
                    diagonalTwoCounter++;
                }
            }
            return diagonalOneCounter + diagonalTwoCounter;
        }


    }

}

