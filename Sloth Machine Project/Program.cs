namespace Sloth_Machine_Project
{
    internal class Program
    {
        const int MIN_RAND_NUMBER = 0;
        const int MAX_RAND_NUMBER = 20;
        const int NUMBER_OF_ROWS = 3;
        const int MIN_BET_AMOUNT = 1;
        const int NUMBER_OF_COLUMNS = 3;
        const int MIN_ROWANDCOLUMN_LOSS = 6;
        const int MIN_ROWONLY_LOSS = 3;
        const int MIN_COLUMNONLY_LOSS = 3;
        const int MIN_DIAGONAL_LOSS = 2;
        const int BET_DECISION_YES = 1;
        const int BET_DECISION_NO = 0;
        const int LINE_MATCH_COUNTER = 1;
        //const int NO_LINE_MATCH_COUNTER = 1;

        public static readonly Random generator = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the slot machine game\n");

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

            int betDecision;
            int numberOfRows = arrayNumbers.GetLength(0);
            int numberOfCols = arrayNumbers.GetLength(1);
            int diagonalLength = 3;
            bool rowLineMatch = true;
            bool columnLineMatch = true;
            bool diagonalOneLineMatch = true;
            bool diagonalTwoLineMatch = true;

            Console.WriteLine("There are three horizontal and three vertical lines available to bet on");
            Console.WriteLine("You can make a bet for one line or more. A bet for one line costs $1");
            Console.WriteLine("The amount you bet either increases or reduces depending whether you win " +
                "or lose");
            Console.WriteLine("The game ends after three betting attempts or if your bet amount is " +
                "depleted before the third attempt");
            Console.WriteLine();

            Console.WriteLine("Enter '1' to make a bet, or '0' to quit");
            betDecision = int.Parse(Console.ReadLine());
            Console.WriteLine();

            if (betDecision == BET_DECISION_NO)
            {
                Console.WriteLine("You have decided to quit this game");
            }

            else if (betDecision == BET_DECISION_YES)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter the dollar amount you want to bet");
                double betAmount = double.Parse(Console.ReadLine());

                while (betAmount > MIN_BET_AMOUNT)
                {
                    Console.WriteLine();
                    Console.WriteLine("**************************************");
                    Console.WriteLine();
                    Console.WriteLine("Please enter 'A' to bet all the lines OR 'H' " +
                        "to bet horizontal lines only or 'V' to bet vertical lines only or 'D'" +
                        " to bet diagonal lines only. $1 per line");
                    Console.WriteLine();

                    string input = Console.ReadLine();
                    string betLineChoice = input.ToUpper();

                    if (betLineChoice == "A")
                    {
                        int allRowCounter = 0;
                        int allColumnCounter = 0;
                        if (betAmount < MIN_BET_AMOUNT)// $1 per line for six lines (3 horizontals + 3 verticals)
                        {
                            Console.WriteLine("Your bet amount is low");
                            break;
                        }
                        else 
                        {
                            //implmentation for rows
                            for (int rowIndex = 0; rowIndex < numberOfRows; rowIndex++)
                            {
                                for (int columnIndex = 0; columnIndex < numberOfCols; columnIndex++)
                                {
                                    if (arrayNumbers[rowIndex, 0] != arrayNumbers[rowIndex, columnIndex])
                                    {
                                        rowLineMatch = false;
                                    }

                                }

                                if (rowLineMatch)
                                {
                                    allRowCounter++;
                                }
                            }

                            //implmentation for columns
                            for (int rowIndex = 0; rowIndex < numberOfRows; rowIndex++)
                            {
                                for (int columnIndex = 0; columnIndex < numberOfCols; columnIndex++)
                                {
                                    if (arrayNumbers[columnIndex, 0] != arrayNumbers[rowIndex, columnIndex])
                                    {
                                        columnLineMatch = false;
                                    }
                                }

                                if (columnLineMatch)
                                {
                                    allColumnCounter++;
                                }
                            }

                            //winning and losing conditions
                            //using the row and/or column counter to increase or decrease the bet amount
                            if (allRowCounter >= LINE_MATCH_COUNTER || allColumnCounter >= LINE_MATCH_COUNTER)
                            {
                                betAmount = betAmount + allRowCounter + allColumnCounter;
                                Console.WriteLine("You have produced at least a winning row combination");
                                Console.WriteLine($"Your row and column bet amount has increased to: ${betAmount}");
                            }

                            else 
                            //if (allRowCounter == NO_LINE_MATCH_COUNTER && allColumnCounter == NO_LINE_MATCH_COUNTER)
                            {
                                betAmount = betAmount - MIN_ROWANDCOLUMN_LOSS;
                                Console.WriteLine("You have not produced a winning row combination");
                                Console.WriteLine($"Your row and column bet amount has reduced to: ${betAmount}");
                            }
                        }

                    }

                    if (betLineChoice == "H")
                    {
                        int horizontalRowCounter = 0;
                        if (betAmount < MIN_BET_AMOUNT) //$1 per line for three lines (3 horizontals)
                        {
                            Console.WriteLine("Your bet amount is low");
                            break;
                        }
                        else
                        {
                            //implmentation for rows
                            for (int rowIndex = 0; rowIndex < numberOfRows; rowIndex++)
                            {
                                for (int columnIndex = 0; columnIndex < numberOfCols; columnIndex++)
                                {
                                    if (arrayNumbers[rowIndex, 0] != arrayNumbers[rowIndex, columnIndex])
                                    {
                                        rowLineMatch = false;
                                    }
                                }

                                if (rowLineMatch)
                                {
                                    horizontalRowCounter++;
                                }
                            }

                            //winning and losing conditions
                            //using the row and/or column counter to increase or decrease the bet amount
                            if (horizontalRowCounter >= LINE_MATCH_COUNTER)
                            {
                                betAmount = betAmount + horizontalRowCounter;
                                Console.WriteLine("You have produced at least a winning row combination");
                                Console.WriteLine($"Your row only bet amount has increased to: ${betAmount}");
                            }

                            else
                            {
                                betAmount = betAmount - MIN_ROWONLY_LOSS;
                                Console.WriteLine("You have not produced a winning row combination");
                                Console.WriteLine($"Your row only bet amount has reduced to: ${betAmount}");
                            }

                        }
                    }

                    if (betLineChoice == "V")
                    {
                        int verticalColumnCounter = 0;
                        if (betAmount < MIN_BET_AMOUNT) //$1 per line for three lines (3 verticals)
                        {
                            Console.WriteLine("Your bet amount is low");
                            break;
                        }
                        else 
                        {
                            for (int rowIndex = 0; rowIndex < numberOfRows; rowIndex++)
                            {
                                for (int columnIndex = 0; columnIndex < numberOfCols; columnIndex++)
                                {
                                    if (arrayNumbers[columnIndex, 0] != arrayNumbers[rowIndex, columnIndex])
                                    {
                                        columnLineMatch = false;
                                    }
                                }

                                if (columnLineMatch)
                                {
                                    verticalColumnCounter++;
                                }
                            }
                        }
                        //winning and losing conditions
                        //using the row and/or column counter to increase or decrease the bet amount
                        if (verticalColumnCounter >= LINE_MATCH_COUNTER)
                        {
                            betAmount = betAmount + verticalColumnCounter;
                            Console.WriteLine("You have produced at least a winning row combination");
                            Console.WriteLine($"Your column only bet amount has increased to: ${betAmount}");
                        }
                        else
                        {
                            betAmount = betAmount - MIN_COLUMNONLY_LOSS;
                            Console.WriteLine("You have not produced a winning row combination");
                            Console.WriteLine($"Your column only bet amount has reduced to: ${betAmount}");
                        }
                    }

                    if (betLineChoice == "D")
                    {
                        int diagonalOneCounter = 0;
                        int diagonalTwoCounter = 0;
                        if (betAmount < MIN_BET_AMOUNT) //$1 per line for two lines (2 diagonal lines)
                        {
                            Console.WriteLine("Your bet amount is low");
                            break;
                        }
                        else
                        {
                            //implementation for diagonals
                            for (int diagonalIndex = 0; diagonalIndex < diagonalLength; diagonalIndex++)
                            {
                                if (arrayNumbers[diagonalIndex, diagonalIndex] != arrayNumbers[diagonalIndex, diagonalIndex])
                                {
                                    diagonalOneLineMatch = false;
                                }

                                if (arrayNumbers[diagonalIndex, 2 - diagonalIndex] != arrayNumbers[diagonalIndex, 2 - diagonalIndex])
                                {
                                    diagonalTwoLineMatch = false;
                                }
                                
                                if (diagonalOneLineMatch)
                                {
                                    diagonalOneCounter++;
                                }

                                if (diagonalTwoLineMatch)
                                {
                                    diagonalTwoCounter++;
                                }
                            }

                        }

                        //winning and losing conditions
                        //using the diagonal counter to increase or decrease the bet amount
                        if (diagonalOneCounter == LINE_MATCH_COUNTER || diagonalTwoCounter == LINE_MATCH_COUNTER)
                        {
                            betAmount = betAmount + diagonalOneCounter + diagonalTwoCounter;
                            Console.WriteLine("You have produced a winning diagonal combination");
                            Console.WriteLine($"Your diagonal only bet amount has increased to: ${betAmount}");
                        }
                        else
                        {
                            betAmount = betAmount - MIN_DIAGONAL_LOSS;
                            Console.WriteLine("You have not produced a winning diagonal combination");
                            Console.WriteLine($"Your diagonal only bet amount has reduced to: ${betAmount}");
                        }
                    }
                }

                if (betAmount < MIN_BET_AMOUNT)
                {
                    Console.WriteLine("You do not have adequate bet amount left");
                }

            }
            Console.WriteLine("The end of the game");
        }
    }
}