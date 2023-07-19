namespace Sloth_Machine_Project
{
    internal class Program
    {
        const int minRandNumber = 0;
        const int maxRandNumber = 20;
        const int numberOfRows = 3;
        const int numberOfColumns = 3;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the slot machine game\n");

            int wager = 3;
            Random generator = new Random();
            int[,] arrayNumbers = new int[numberOfRows, numberOfColumns];

            for (int row = 0; row < numberOfRows; row++)
            {
                for (int column = 0; column < numberOfColumns; column++)
                {
                    arrayNumbers[row, column] = generator.Next(minRandNumber, maxRandNumber);
                    //Console.Write(arrayNumbers[row, column]);
                }
            }
            Console.Write(arrayNumbers[0, 0]);
            Console.Write(",");
            Console.Write(arrayNumbers[0, 1]);
            Console.Write(",");
            Console.Write(arrayNumbers[0, 2]);
            Console.WriteLine();
            Console.Write(arrayNumbers[1, 0]);
            Console.Write(",");
            Console.Write(arrayNumbers[1, 1]);
            Console.Write(",");
            Console.Write(arrayNumbers[1, 2]);
            Console.WriteLine();
            Console.Write(arrayNumbers[2, 0]);
            Console.Write(",");
            Console.Write(arrayNumbers[2, 1]);
            Console.Write(",");
            Console.Write(arrayNumbers[2, 2]);
            Console.WriteLine("\n");

            Console.WriteLine("Wager for the Sloth Machine above is $3");
            Console.WriteLine("Enter 1 to make a wager, 0 to quit");
            int wagerDecision = int.Parse(Console.ReadLine());

            if (arrayNumbers[1, 0] == arrayNumbers[1, 1] && arrayNumbers[1, 0] == arrayNumbers[1, 2])
            {
                Console.WriteLine($"Your wager produced: {arrayNumbers[1, 0]}, {arrayNumbers[1, 1]}, {arrayNumbers[1, 2]}");
                Console.WriteLine("You win $1");
                wager++;
                Console.WriteLine($"Your wager has increased to: {wager}");
            }

            else
            {
                Console.WriteLine($"Your wager produced: {arrayNumbers[1, 0]}, {arrayNumbers[1, 1]}, {arrayNumbers[1, 2]}");
                Console.WriteLine("They did not match. You lose");
            }
        }
    }
    
}