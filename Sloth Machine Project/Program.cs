using Sloth_Machine_Project;
namespace Refactored_Slot_Machine
{
    internal class Program
    {
        const int MIN_BET_AMOUNT = 1;
        const int LINE_MATCH_COUNTER = 1;
        const int MIN_ROWONLY_LOSS = 3;
        const int MIN_COLUMNONLY_LOSS = 3;
        const int MIN_DIAGONAL_LOSS = 2;

        static void Main(string[] args)
        {
            bool keepPlaying = true;
            double bank = 0;

            SlotMachineMethods.ShowWelcomeToTheGame();
            SlotMachineMethods.ShowGameDescription();
            Console.WriteLine();
            bool wantsToBet = SlotMachineMethods.MakeBetDecision();

            if (wantsToBet)
            {
                double storeBetAmount = SlotMachineMethods.GetBetAmount();
                bank = bank + storeBetAmount;
                Console.WriteLine();
            }

            while (keepPlaying)
            {
                int[,] arrayGen = SlotMachineMethods.GetRandom2DArray();

                while (bank > MIN_BET_AMOUNT)
                {
                    SlotMachineMethods.BettingLinesInstruction();
                    string betSelection = SlotMachineMethods.BettingLinesResponse();

                    if (betSelection == "H" || betSelection == "A")
                    {
                        int numberOfRowMatches = SlotMachineMethods.RowImplementation(arrayGen);

                        int rowCounter = numberOfRowMatches;

                        if (rowCounter >= LINE_MATCH_COUNTER)
                        {
                            double increaseRowBetAmount = SlotMachineMethods.PromptBetAmountIncrease(bank, MIN_ROWONLY_LOSS);
                        }

                        if (rowCounter < LINE_MATCH_COUNTER)
                        {
                            double decreaseRowBetAmount = SlotMachineMethods.PromptBetAmountDecrease(bank, MIN_ROWONLY_LOSS);
                        }
                    }
                    Console.WriteLine();


                    if (betSelection == "V" || betSelection == "A")
                    {
                        int numberOfColumnMatches = SlotMachineMethods.ColumnImplementation(arrayGen);

                        int columnCounter = numberOfColumnMatches;

                        if (columnCounter >= LINE_MATCH_COUNTER)
                        {
                            double increaseColumnBetAmount = SlotMachineMethods.PromptBetAmountIncrease(bank, MIN_COLUMNONLY_LOSS);
                        }

                        if (columnCounter < LINE_MATCH_COUNTER)
                        {
                            double decreaseColumnBetAmount = SlotMachineMethods.PromptBetAmountDecrease(bank, MIN_COLUMNONLY_LOSS);
                        }
                    }
                    Console.WriteLine();

                    if (betSelection == "D")
                    {
                        int numberOfDiagonalMatches = SlotMachineMethods.DiagonalImplementation(arrayGen);
                        int diagonalCounter = numberOfDiagonalMatches;

                        if (diagonalCounter >= LINE_MATCH_COUNTER)
                        {
                            double increaseDiagonalBetAmount = SlotMachineMethods.PromptBetAmountIncrease(bank, MIN_DIAGONAL_LOSS);
                            increaseDiagonalBetAmount += MIN_DIAGONAL_LOSS;
                        }

                        if (diagonalCounter < LINE_MATCH_COUNTER)
                        {
                            double decreaseColumnBetAmount = SlotMachineMethods.PromptBetAmountDecrease(bank, MIN_DIAGONAL_LOSS);
                            decreaseColumnBetAmount -= MIN_DIAGONAL_LOSS;
                        }
                    }
                    Console.WriteLine();
                }

                if (bank < MIN_BET_AMOUNT)
                {
                    SlotMachineMethods.MakeAnotherBet();
                }
            }
        }
    }
}

