using Sloth_Machine_Project;
namespace Refactored_Slot_Machine
{
    internal class Program
    {
        const int MIN_BET_AMOUNT = 1;
        const int LINE_MATCH_COUNTER = 1;
        
        static void Main(string[] args)
        {
            bool keepPlaying = true;
            double bank = 0;

            UIMethods.ShowWelcomeToTheGame();
            UIMethods.ShowGameDescription();
            Console.WriteLine();

            keepPlaying = LogicMethods.MakeBetDecision();

            if (keepPlaying == true)
            {
                double storeBetAmount = LogicMethods.GetBetAmount();
                bank = bank + storeBetAmount;
                Console.WriteLine();
            }

            else 
            {
                Console.WriteLine("You have decided not to make a bet.");
            }

            while (keepPlaying)
            {
                int[,] arrayGen = LogicMethods.GetRandom2DArray();

                while (bank > MIN_BET_AMOUNT)
                {
                    UIMethods.BettingLinesInstruction();
                    string betSelection = UIMethods.BettingLinesResponse();

                    if (betSelection == "H" || betSelection == "A")
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
                    Console.WriteLine();


                    if (betSelection == "V" || betSelection == "A")
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
                    Console.WriteLine();

                    if (betSelection == "D")
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
                    Console.WriteLine();
                }
            }
        }
    }
}

