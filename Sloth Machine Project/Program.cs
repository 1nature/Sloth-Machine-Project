namespace Sloth_Machine_Project
{
    internal class Program
    {
        const int MIN_RAND_NUMBER = 0;
        const int MAX_RAND_NUMBER = 20;
        const int NUMBER_OF_ROWS = 3;
        const int NUMBER_OF_COLUMNS = 3;
        const int MIN_ROWANDCOLUMN_BET = 6;
        const int MIN_ROWONLY_BET = 3;
        const int MIN_COLUMNONLY_BET = 3;
        const int DIAGONAL_ONE_ONLY_BET = 3;

        //what is the meaning of public static?
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
            int horizontalRowCounter = 0;
            int verticalColumnCounter = 0;
            int allRowCounter = 0;
            int allColumnCounter = 0;
            int numberOfRows = arrayNumbers.GetLength(0);
            int numberOfCols = arrayNumbers.GetLength(1);
            bool rowLineMatch = true;
            bool columnLineMatch = true;
            string playAgainDecision;

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

            if (betDecision == 0)
            {
                Console.WriteLine("You have decided to quit this game");
            }

            else if (betDecision == 1)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter the dollar amount you want to bet");
                double betAmount = double.Parse(Console.ReadLine());

                while (betAmount > 1)
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
                        if (betAmount < MIN_ROWANDCOLUMN_BET)// $6 for six lines (3 horizontals + 3 verticals)
                        {
                            Console.WriteLine("Your bet amount is low");
                            break;
                        }

                        else if (betAmount >= MIN_ROWANDCOLUMN_BET) //$6 for six lines (3 horizontals + 3 verticals)
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

                        }

                        //winning and losing conditions
                        //using the row and/or column counter to increase or decrease the bet amount
                        if (allRowCounter >= 1 || allColumnCounter >= 1)
                        {
                            betAmount = betAmount + allRowCounter + allColumnCounter;
                            Console.WriteLine("You have produced at least a winning row combination");
                            Console.WriteLine($"Your row and column bet amount has increased to: ${betAmount}");
                        }

                        else if (allRowCounter == 0 && allColumnCounter == 0)
                        {
                            betAmount = betAmount - MIN_ROWANDCOLUMN_BET;
                            Console.WriteLine("You have not produced a winning row combination");
                            Console.WriteLine($"Your row and column bet amount has reduced to: ${betAmount}");
                        }
                    }

                    else if (betLineChoice == "H")
                    {
                        if (betAmount < 3) //$3 for three lines (3 horizontals)
                        {
                            //keepPlaying = false;
                            Console.WriteLine("Your bet amount is low");
                            break;
                        }

                        else if (betAmount >= 3) //$3 for three lines (3 horizontals)
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

                        }

                        //winning and losing conditions
                        //using the row and/or column counter to increase or decrease the bet amount
                        if (horizontalRowCounter >= 1)
                        {
                            betAmount = betAmount + horizontalRowCounter;
                            Console.WriteLine("You have produced at least a winning row combination");
                            Console.WriteLine($"Your row only bet amount has increased to: ${betAmount}");
                        }

                        else if (horizontalRowCounter == 0)
                        {
                            betAmount = betAmount - MIN_ROWONLY_BET;
                            Console.WriteLine("You have not produced a winning row combination");
                            Console.WriteLine($"Your row only bet amount has reduced to: ${betAmount}");
                        }
                    }

                    else if (betLineChoice == "V")
                    {
                        if (betAmount < 3) //$3 for three lines (3 verticals)
                        {
                            //keepPlaying = false;
                            Console.WriteLine("Your bet amount is low");
                            break;
                        }

                        else if (betAmount >= 3) //$3 for three lines (3 vertical ones)
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
                        if (verticalColumnCounter >= 1)
                        {
                            betAmount = betAmount + verticalColumnCounter;
                            Console.WriteLine("You have produced at least a winning row combination");
                            Console.WriteLine($"Your column only bet amount has increased to: ${betAmount}");
                        }

                        else if (verticalColumnCounter == 0)
                        {
                            betAmount = betAmount - MIN_COLUMNONLY_BET;
                            Console.WriteLine("You have not produced a winning row combination");
                            Console.WriteLine($"Your column only bet amount has reduced to: ${betAmount}");
                        }
                    }

                    if (betAmount < 1 || betAmount < MIN_ROWANDCOLUMN_BET || betAmount < MIN_ROWONLY_BET)
                    {
                        Console.WriteLine("You do not have adequate bet amount left");

                    }

                    else if (betDecision == 0)
                    {
                        Console.WriteLine("You have decided to quit");
                    }

                    Console.WriteLine("The end of the game");

                }
            }

        }
    }
}