namespace Sloth_Machine_Project
{
    internal class Program
    {
        const int MINRANDNUMBER = 0;
        const int MAXRANDNUMBER = 20;
        const int NUMBEROFROWS = 3;
        const int NUMBEROFCOLUMNS = 3;

        public static readonly Random generator = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the slot machine game\n");

            int wager = 3; //Dollar amount
            int wagerLoss = 3; //Dollar amount
            int numberOfAttempts = 3;
            int remainingAttempts = 3;
            int wagerDecision;
            bool keepPlaying = true;

            int[,] arrayNumbers = new int[NUMBEROFROWS, NUMBEROFCOLUMNS];

            for (int row = 0; row < arrayNumbers.GetLength(0); row++)
            {
                for (int column = 0; column < arrayNumbers.GetLength(1); column++)
                {
                    arrayNumbers[row, column] = generator.Next(MINRANDNUMBER, MAXRANDNUMBER);
                    Console.Write(arrayNumbers[row, column] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Wager for the Sloth Machine above is $3");
            Console.WriteLine("Enter 1 to make a wager, 0 to quit");
            Console.WriteLine();

            while (keepPlaying)
            {
                for (int tries = 0; tries < numberOfAttempts; tries++)
                {
                    wagerDecision = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    if (wagerDecision == 0)
                    {
                        Console.WriteLine("You have decided to quit this game");
                        break;
                    }

                    else if (wagerDecision == 1)
                    {
                        //for the horizontal combination
                        if (arrayNumbers[0, 0] == arrayNumbers[0, 1] && arrayNumbers[0, 0] == arrayNumbers[0, 2])
                        {
                            Console.WriteLine($"Your wager produced: {arrayNumbers[0, 0]}, {arrayNumbers[0, 1]}, {arrayNumbers[0, 2]}");
                            Console.WriteLine("You win $1");
                            wager++;
                            Console.WriteLine($"Your wager has increased to: ${wager}");
                        }

                        else if (arrayNumbers[1, 0] == arrayNumbers[1, 1] && arrayNumbers[1, 0] == arrayNumbers[1, 2])
                        {
                            Console.WriteLine($"Your wager produced: {arrayNumbers[1, 0]}, {arrayNumbers[1, 1]}, {arrayNumbers[1, 2]}");
                            Console.WriteLine("You win $1");
                            wager++;
                            Console.WriteLine($"Your wager has increased to: ${wager}");
                        }

                        else if (arrayNumbers[2, 0] == arrayNumbers[2, 1] && arrayNumbers[2, 0] == arrayNumbers[2, 2])
                        {
                            Console.WriteLine($"Your wager produced: {arrayNumbers[2, 0]}, {arrayNumbers[2, 1]}, {arrayNumbers[2, 2]}");
                            Console.WriteLine("You win $1");
                            wager++;
                            Console.WriteLine($"Your wager has increased to: ${wager}");
                        }

                        //for the diagonal combination
                        else if (arrayNumbers[0, 0] == arrayNumbers[1, 1] && arrayNumbers[0, 0] == arrayNumbers[2, 2])
                        {
                            Console.WriteLine($"Your wager produced: {arrayNumbers[0, 0]}, {arrayNumbers[1, 1]}, {arrayNumbers[2, 2]}");
                            Console.WriteLine("You win $1");
                            wager++;
                            Console.WriteLine($"Your wager has increased to: ${wager}");
                        }

                        else if (arrayNumbers[2, 0] == arrayNumbers[1, 1] && arrayNumbers[2, 0] == arrayNumbers[0, 2])
                        {
                            Console.WriteLine($"Your wager produced: {arrayNumbers[2, 0]}, {arrayNumbers[1, 1]}, {arrayNumbers[0, 2]}");
                            Console.WriteLine("You win $1");
                            wager++;
                            Console.WriteLine($"Your wager has increased to: ${wager}");
                        }

                        else
                        {
                            Console.WriteLine("Your attempt has not produced a winning combination. Please try again");
                            wagerLoss--;
                            Console.WriteLine($"Your wager has decreased to: ${wagerLoss}");
                        }
                        remainingAttempts--;
                        Console.WriteLine($"Remaining attempts = {remainingAttempts}");
                    }
                }

                if (remainingAttempts == wagerLoss || wager == 6)
                {
                    break;
                }
            }

            Console.WriteLine("End of the game");
        }
    }

}