using Refactored_Slot_Machine;

namespace Sloth_Machine_Project
{
    public static class LogicMethods
    {
        public static readonly Random generator = new Random();

        /// <summary>
        /// Random array numbers generator
        /// </summary>
        /// <returns>random array numbers</returns>
        public static int[,] GetRandom2DArray()
        {
            int[,] arrayNumbers = new int[Constants.NUMBER_OF_ROWS, Constants.NUMBER_OF_COLUMNS];

            for (int row = 0; row < arrayNumbers.GetLength(0); row++)
            {
                for (int column = 0; column < arrayNumbers.GetLength(1); column++)
                {
                    arrayNumbers[row, column] = generator.Next(Constants.MIN_RAND_NUMBER, Constants.MAX_RAND_NUMBER + 1);
                }
            }
            return arrayNumbers;
        }

        /// <summary>
        /// Checks whether the horizontal lines match after a user bet
        /// </summary>
        /// <param name="slotArray"></param>
        /// <returns>the number of winning lines</returns>
        public static int CheckHorizontalLinesWinning(int[,] slotArray)
        {
            bool lineMatch = true;
            int horizontalRowCounter = 0;

            for (int rowIndex = 0; rowIndex < Constants.NUMBER_OF_ROWS; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < Constants.NUMBER_OF_COLUMNS; columnIndex++)
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

        /// <summary>
        /// Checks whether the vertical lines match after a user bet
        /// </summary>
        /// <param name="slotArray"></param>
        /// <returns>the number of winning lines</returns>
        public static int CheckVerticalLinesWinning(int[,] slotArray)
        {
            bool lineMatch = true;
            int verticalColumnCounter = 0;

            for (int columnIndex = 0; columnIndex < Constants.NUMBER_OF_ROWS; columnIndex++)
            {
                for (int rowIndex = 0; rowIndex < Constants.NUMBER_OF_COLUMNS; rowIndex++)
                {
                    if (slotArray[0, columnIndex] != slotArray[rowIndex, columnIndex])
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

        /// <summary>
        /// Checks whether the left-to-right diagonal lines match after a user bet
        /// </summary>
        /// <param name="slotArray"></param>
        /// <returns>the number of winning lines</returns>
        public static int CheckDiagonalOneLineWinning(int[,] slotArray)
        {
            bool lineMatch = true;
            int diagonalOneCounter = 0;

            for (int diagonalIndex = 0; diagonalIndex < Constants.DIAGONALONELENGTH; diagonalIndex++)
            {
                if (slotArray[diagonalIndex, diagonalIndex] != slotArray[diagonalIndex + Constants.SINGLEINCREMENT, diagonalIndex + Constants.SINGLEINCREMENT])
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

        /// <summary>
        /// Checks whether the right-to-left diagonal lines match after a user bet
        /// </summary>
        /// <param name="slotArray"></param>
        /// <returns>the number of winning lines</returns>
        public static int CheckDiagonalTwoLineWinning(int[,] slotArray)
        {
            bool lineMatch = true;
            int diagonalTwoCounter = 0;

            for (int diagonalIndex = 0; diagonalIndex < Constants.DIAGONALTWOLENGTH; diagonalIndex++)
            {
                if (slotArray[diagonalIndex, Constants.DIAGONAL_ONE_MAX_INDEX - diagonalIndex] != slotArray[diagonalIndex, Constants.DIAGONAL_ONE_MAX_INDEX - diagonalIndex])
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

        /// <summary>
        /// This either increases or decreases the bet amount
        /// </summary>
        /// <param name="lineMatchingCount"></param>
        /// <returns>a result that either increments or decrements the bet amount </returns>
        public static int CheckOnWinningAmount(int lineMatchingCount)
        {
            int result;
            if (lineMatchingCount >= Constants.LINE_MATCH_COUNTER)
            {
                result = lineMatchingCount;
            }
            else
            {
                result = (- Constants.LINE_MATCH_COUNTER);
            }
            return result;
        }
    }
}

