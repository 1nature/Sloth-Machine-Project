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

            int wager = 3;
            int[,] arrayNumbers = new int[NUMBEROFROWS, NUMBEROFCOLUMNS];

            for (int row = 0; row < NUMBEROFROWS; row++)
            {
                for (int column = 0; column < NUMBEROFCOLUMNS; column++)
                {
                    arrayNumbers[row, column] = generator.Next(MINRANDNUMBER, MAXRANDNUMBER);
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