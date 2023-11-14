namespace Sloth_Machine_Project
{
    public static class LogicMethods
    {
        const int MIN_RAND_NUMBER = 0;
        const int MAX_RAND_NUMBER = 20;
        const int NUMBER_OF_ROWS = 3;
        const int NUMBER_OF_COLUMNS = 3;
        const int BET_DECISION_YES = 1;
        const int BET_DECISION_N0 = 0;
        const int MIN_BET_AMOUNT = 1;

        public static readonly Random generator = new Random();

        public static int[,] GetRandom2DArray()
        {
            int[,] arrayNumbers = new int[NUMBER_OF_ROWS, NUMBER_OF_COLUMNS];

            for (int row = 0; row < arrayNumbers.GetLength(0); row++)
            {
                for (int column = 0; column < arrayNumbers.GetLength(1); column++)
                {
                    arrayNumbers[row, column] = generator.Next(MIN_RAND_NUMBER, MAX_RAND_NUMBER + 1);
                }
            }
            return arrayNumbers;
        }
        

        public static bool MakeBetDecision()
        {
            Console.WriteLine("Enter '1' to make a bet, or '0' to quit.");
            int betDecision = int.Parse(Console.ReadLine());
            Console.WriteLine();
                return (betDecision == BET_DECISION_YES);
        }

        public static void MakeAnotherBet()
        {
            bool theBetDecision = LogicMethods.MakeBetDecision();
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

        public static double GetBetAmount()
        {
            Console.WriteLine("Please enter the dollar amount you want to bet\n");
            double amountToBet = double.Parse(Console.ReadLine());
            return amountToBet;
        }

        public static int RowImplementation(int[,] slotArray)
        {
            bool lineMatch = true;
            int horizontalRowCounter = 0;

            for (int rowIndex = 0; rowIndex < NUMBER_OF_ROWS; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < NUMBER_OF_COLUMNS; columnIndex++)
                {
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
            bool lineMatch = true;
            int verticalColumnCounter = 0;

            for (int rowIndex = 0; rowIndex < NUMBER_OF_ROWS; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < NUMBER_OF_COLUMNS; columnIndex++)
                {

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

        public static int DiagonalImplementation(int[,] slotArray)
        {
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

