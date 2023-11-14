using Sloth_Machine_Project;
namespace Refactored_Slot_Machine
{
    internal class Program
    {
        const int MIN_BET_AMOUNT = 1;
        const int LINE_MATCH_COUNTER = 1;
        public const char LINE_TYPE_ALL = 'A';
        public const char LINE_TYPE_HOR = 'H';
        public const char LINE_TYPE_VER = 'V';
        public const char LINE_TYPE_DIA = 'D';

        static void Main(string[] args)
        {
            bool keepPlaying = true;
            double bank = 0;

            UIMethods.ShowWelcomeToTheGame();
            UIMethods.ShowGameDescription();
            UIMethods.WriteEmptyLine();

            keepPlaying = UIMethods.MakeBetDecision();

            if (keepPlaying == true)
            {
                double storeBetAmount = UIMethods.GetBetAmount();
                bank = bank + storeBetAmount;
                UIMethods.WriteEmptyLine();
            }

            else 
            {
                Console.WriteLine("You have decided not to make a bet.");
            }

            while (keepPlaying)
            {
                int[,] arrayGen = LogicMethods.GetRandom2DArray();
                //UIMethods.Print2DArray(arrayGen);

                while (bank > MIN_BET_AMOUNT)
                {
                    UIMethods.BettingLinesInstruction();
                    char betSelection = UIMethods.BettingLinesResponse();

                    if (betSelection == LINE_TYPE_HOR || betSelection == LINE_TYPE_ALL)
                    {
                        int numberOfRowMatches = LogicMethods.RowImplementation(arrayGen);

                        int rowCounter = numberOfRowMatches;

                        if (rowCounter >= LINE_MATCH_COUNTER)
                        {
                            double increaseRowBetAmount = bank + rowCounter;
                            UIMethods.PrintBetAmountIncrease(increaseRowBetAmount);
                        }

                        else
                        {
                            double decreaseRowBetAmount = bank - rowCounter;
                            UIMethods.PrintBetAmountDecrease(decreaseRowBetAmount);
                        }
                    }
                    UIMethods.WriteEmptyLine();


                    if (betSelection == LINE_TYPE_VER || betSelection == LINE_TYPE_ALL)
                    {
                        int numberOfColumnMatches = LogicMethods.ColumnImplementation(arrayGen);

                        int columnCounter = numberOfColumnMatches;

                        if (columnCounter >= LINE_MATCH_COUNTER)
                        {
                            double increaseColumnBetAmount = bank + columnCounter;
                            UIMethods.PrintBetAmountIncrease(increaseColumnBetAmount);
                        }

                        else
                        {
                            double decreaseColumnBetAmount = bank - columnCounter;
                            UIMethods.PrintBetAmountDecrease(decreaseColumnBetAmount);
                        }
                    }
                    UIMethods.WriteEmptyLine();

                    if (betSelection == LINE_TYPE_DIA)
                    {
                        int numberOfDiagonalMatches = LogicMethods.DiagonalImplementation(arrayGen);
                        int diagonalCounter = numberOfDiagonalMatches;

                        if (diagonalCounter >= LINE_MATCH_COUNTER)
                        {
                            double increaseDiagonalBetAmount = bank + diagonalCounter;
                            UIMethods.PrintBetAmountIncrease(increaseDiagonalBetAmount);
                        }

                        else
                        {
                            double decreaseDiagonalBetAmount = bank - diagonalCounter;
                            UIMethods.PrintBetAmountDecrease(decreaseDiagonalBetAmount);
                        }
                    }
                    UIMethods.WriteEmptyLine();
                }
            }
        }
    }
}

