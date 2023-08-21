namespace Sloth_Machine_Project
{
    internal class Program
    {
        const int MIN_RAND_NUMBER = 0;
        const int MAX_RAND_NUMBER = 20;
        const int NUMBER_OF_ROWS = 3;
        const int NUMBER_OF_COLUMNS = 3;
        const int ZERO = 0;
        const int NUMBER_OF_ATTEMPTS = 3;
        const int BET_WIN = 1;
        const int BET_LOSS = 1;
        const int ONE = 1;

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

            int wager = 3; //Dollar amount
            int remainingAttempts = 3;
            int betDecision;
            int rowCounter = 0;
            int columnCounter = 0;
            bool keepPlaying = true;
            int numberOfRows = arrayNumbers.GetLength(0);
            int numberOfCols = arrayNumbers.GetLength(1);
            bool rowLineMatch = true;
            double rowBetAmount = 0;


            while (keepPlaying)
            {
                Console.WriteLine();
                Console.WriteLine("**************************************");
                Console.WriteLine("Enter 1 to make a bet, 0 to quit");
                betDecision = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (betDecision == ZERO)
                {
                    keepPlaying = false;
                    Console.WriteLine("You have decided to quit this game");
                    break;
                }

                else if (betDecision == ONE)
                {
                    Console.WriteLine("Please enter the amount you want to bet");
                    double betAmount = double.Parse(Console.ReadLine());
                    Console.WriteLine();

                    //implmentation for rows
                    for (int rowIndex = 0; rowIndex < numberOfRows; rowIndex++)
                    {
                        for (int columnIndex = 0; columnIndex < numberOfCols; columnIndex++)
                        {
                            if (arrayNumbers[rowIndex, 0] != arrayNumbers[rowIndex, columnIndex])
                            {
                                rowLineMatch = true;
                            }

                            else
                            {
                                rowLineMatch = false;
                            }
                        }

                        if (rowLineMatch)
                        {
                            rowCounter++;
                        }
                    }

                    if (rowCounter >= ONE)
                    {
                        rowBetAmount = betAmount + BET_WIN;
                        Console.WriteLine("You have produced at least a winning row combination");
                        Console.WriteLine($"Your wager has increased to: ${rowBetAmount}");
                    }

                    else
                    {
                        rowBetAmount = betAmount - BET_LOSS;
                        Console.WriteLine("You have not produced a winning row combination");
                        Console.WriteLine($"Your bet amount has reduced to: ${rowBetAmount}");
                    }
                }
                remainingAttempts--;
                Console.WriteLine($"Your remaining attempt(s) = {remainingAttempts}");

                if (remainingAttempts == ZERO)
                {
                    break;
                }
            }

            //this is embarrassing but the I can't get this code to playAgain!
            Console.WriteLine();
            Console.WriteLine("Enter 1 if you would like to play again, enter 0 to quit the game");
            int playAgain = int.Parse(Console.ReadLine());

            if (playAgain == ZERO)
            {
                keepPlaying = false;
            }

            else if (playAgain == ONE)
            {
                keepPlaying = true; //there is an error if keepPlaying is not assigned to true
                remainingAttempts = NUMBER_OF_ATTEMPTS;
            }
        }

    }

}