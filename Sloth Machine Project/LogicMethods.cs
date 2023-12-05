using Microsoft.VisualBasic;

namespace Sloth_Machine_Project
{
    public static class LogicMethods
    {
        const int MIN_RAND_NUMBER = 0;
        const int MAX_RAND_NUMBER = 20;
        const int NUMBER_OF_ROWS = 3;
        const int NUMBER_OF_COLUMNS = 3;
        const int DIAGONALONELENGTH = 2;
        const int DIAGONALTWOLENGTH = 3;
        const int SINGLEINCREMENT = 1;


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

        public static int RowImplementation(int[,] slotArray)
        {
            bool lineMatch = true;
            int horizontalRowCounter = 0;

            for (int rowIndex = 0; rowIndex < NUMBER_OF_ROWS; rowIndex++)
            {
                for (int columnIndex = 1; columnIndex < NUMBER_OF_COLUMNS; columnIndex++)
                {
                    if (slotArray[rowIndex, 0] != slotArray[rowIndex, columnIndex])
                    {
                        lineMatch = false;
                        break;
                    }
                    else
                    {
                        lineMatch = true;
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
                for (int columnIndex = 1; columnIndex < NUMBER_OF_COLUMNS; columnIndex++)
                {
                    if (slotArray[rowIndex, 0] != slotArray[columnIndex, rowIndex])
                    //change the order
                    {
                        lineMatch = false; break;
                    }

                    else
                    {
                        lineMatch = true;
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

            for (int diagonalIndex = 0; diagonalIndex < DIAGONALONELENGTH; diagonalIndex++)
            {
                if (slotArray[diagonalIndex, diagonalIndex] != slotArray[diagonalIndex + SINGLEINCREMENT, diagonalIndex + SINGLEINCREMENT])
                {
                    lineMatch = false; break;
                }

                else
                {
                    lineMatch = true;
                }
            }

            if (lineMatch)
            {
                diagonalOneCounter++;
            }

            return diagonalOneCounter;
        }

        public static int SecondDiagonalImplementation(int[,] slotArray)
        {
            bool lineMatch = true;
            int diagonalTwoCounter = 0;

            for (int diagonalIndex = 0; diagonalIndex < DIAGONALTWOLENGTH; diagonalIndex++)
            {
                if (slotArray[diagonalIndex, DIAGONALONELENGTH - diagonalIndex] != slotArray[diagonalIndex, DIAGONALONELENGTH - diagonalIndex])
                {
                    lineMatch = false; break;
                }

                else
                {
                    lineMatch = true;
                }
            }

            if (lineMatch)
            {
                diagonalTwoCounter++;
            }

            return diagonalTwoCounter;
        }
    }
}

