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
            Console.WriteLine("Welcome to the slot machine game");

            Random generator = new Random();
            int[,] arrayNumbers = new int[numberOfRows, numberOfColumns];

            for (int row = 0; row < numberOfRows; row++)
            {
                for (int column = 0; column < numberOfColumns; column++)
                {
                    arrayNumbers[row, column] = generator.Next(minRandNumber, maxRandNumber);
                    Console.Write(arrayNumbers[row, column]);
                }
            }
            
        }
    }
}