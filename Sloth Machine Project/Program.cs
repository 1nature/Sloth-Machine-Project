namespace Sloth_Machine_Project
{
    internal class Program
    {
        const int MINRANDNUMBER = 0;
        const int MAXRANDNUMBER = 20;
        const int NUMBEROFROWS = 3;
        const int NUMBEROFCOLUMNS = 3;
        const int MAXCOUNTER = 2;

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
            }
            Console.WriteLine();

            int numberOfIteration = 1;
            int counter = 0;
            int[] midRowTracker = new int[3];
            int[] wrongCombination = new int[3];
            bool keepPlaying = true;

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
                        //implmentation for middle row
                        for (int currentRowIndex = 0; currentRowIndex < numberOfIteration; currentRowIndex++)
                        {

                            if (arrayNumbers[1, currentRowIndex] == arrayNumbers[1, currentRowIndex + 1])
                            {
                                midRowTracker[0] = arrayNumbers[1, currentRowIndex];
                                midRowTracker[1] = arrayNumbers[1, currentRowIndex + 1];
                                counter++;
                            }

                            if (arrayNumbers[1, currentRowIndex + 1] == arrayNumbers[1, currentRowIndex] + 2)
                            {
                                midRowTracker[2] = arrayNumbers[1, currentRowIndex + 2];
                                counter++;
                            }

                            if (counter == MAXCOUNTER)
                            {
                                Console.WriteLine("You have produced a winning combination as shown below");

                                foreach (int rowNumber in midRowTracker)
                                {
                                    Console.Write(rowNumber + "\t");
                                }
                                Console.WriteLine("\n");
                                Console.WriteLine("You win $1");
                                wager++;
                                Console.WriteLine($"Your wager has increased to: ${wager}");
                            }

                            else
                            {
                                wrongCombination[0] = arrayNumbers[1, currentRowIndex];
                                wrongCombination[1] = arrayNumbers[1, currentRowIndex + 1];
                                wrongCombination[2] = arrayNumbers[1, currentRowIndex + 2];

                                Console.WriteLine("Your attempt has produced: ");

                                foreach (int number in wrongCombination)
                                {
                                    Console.Write(number + "\t");

                                }
                                Console.WriteLine("\n");

                                Console.WriteLine("It is not a winning combination");
                                wagerLoss--;
                                Console.WriteLine($"Your wager has decreased to: ${wagerLoss}");
                            }

                        }
                    }
                    remainingAttempts--;
                    Console.WriteLine($"Remaining attempts = {remainingAttempts}");
                }

                if (remainingAttempts == 0)
                {
                    break;
                }
            }
            Console.WriteLine("End of the game");
            Console.WriteLine("\n");
        }
    }

}