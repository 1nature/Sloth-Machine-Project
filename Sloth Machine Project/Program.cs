namespace Sloth_Machine_Project
{
    internal class Program
    {
        const int MINRANDNUMBER = 0;
        const int MAXRANDNUMBER = 20;
        const int NUMBEROFROWS = 3;
        const int NUMBEROFCOLUMNS = 3;
        const int ZERO = 0;

        public static readonly Random generator = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the slot machine game\n");

            int wager = 3; //Dollar amount
            int wagerLoss = 3; //Dollar amount
            int numberOfAttempts = 3;
            int remainingAttempts = 3;
            int wagerDecision;

            int[,] arrayNumbers = new int[NUMBEROFROWS, NUMBEROFCOLUMNS];

            for (int row = 0; row < arrayNumbers.GetLength(0); row++)
            {
                for (int column = 0; column < arrayNumbers.GetLength(1); column++)
                {
                    arrayNumbers[row, column] = generator.Next(MINRANDNUMBER, MAXRANDNUMBER);
                    Console.Write(arrayNumbers[row, column] + "\t"); //just for checks

                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(arrayNumbers[row, 0]);
            }
            Console.WriteLine();
            

            int rowCounter = 0;
            int columnCounter = 0;
            bool keepPlaying = true;
            int numberOfRows = arrayNumbers.GetLength(0);
            int numberOfCols = arrayNumbers.GetLength(1);

            while (keepPlaying)
            {
                for (int tries = 0; tries < numberOfAttempts; tries++)
                {
                    Console.WriteLine();
                    Console.WriteLine("**************************************");
                    Console.WriteLine("Wager for the Slot Machine above is $3");
                    Console.WriteLine("Enter 1 to make a wager, 0 to quit");
                    wagerDecision = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    if (wagerDecision == 0)
                    {
                        keepPlaying = false;
                        Console.WriteLine("You have decided to quit this game");
                        break;
                    }

                    else if (wagerDecision == 1)
                    {
                        //implmentation for rows
                        for (int rowIndex = 0; rowIndex < numberOfRows; rowIndex++)
                        {
                            for (int columnIndex = 0; columnIndex < numberOfCols; columnIndex++)
                            {
                                if (arrayNumbers[rowIndex, 0] == arrayNumbers[rowIndex, columnIndex])
                                {
                                    rowCounter++;
                                }
                            }

                        }

                        //implementation for columns
                        for (int rowIndex = 0; rowIndex < numberOfRows; rowIndex++)
                        {
                            for (int columnIndex = 0; columnIndex < numberOfCols; columnIndex++)
                            {
                                if (arrayNumbers[columnIndex, 0] == arrayNumbers[rowIndex, columnIndex])
                                {
                                    columnCounter++;
                                }
                            }
                        }


                        if (rowCounter == 1 || columnCounter == 1)
                        {
                            Console.WriteLine("You have produced at least one winning combination");
                            Console.WriteLine("You win $1");
                            wager++;
                            Console.WriteLine($"Your wager has increased to: ${wager}");
                        }

                        else
                        {
                            Console.WriteLine("You have not produced a winning combination");
                            wager--;
                            Console.WriteLine($"Your wager has reduced to: ${wager}");
                        }
                    }
                    remainingAttempts--;
                    Console.WriteLine($"Remaining attempts = {remainingAttempts}");
                }
                

                if (remainingAttempts == ZERO || wager == ZERO)
                {
                    break;
                }
            }
            Console.WriteLine("End of the game");
            //Console.ReadKey();
        }
    }
}