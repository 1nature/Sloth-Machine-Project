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

            SlotMachineInAndOutMethods.ShowWelcomeToTheGame();
            SlotMachineInAndOutMethods.ShowGameDescription();
            Console.WriteLine();

            keepPlaying = SlotMachineMethods.MakeBetDecision();

            if (keepPlaying == true)
            {
                double storeBetAmount = SlotMachineMethods.GetBetAmount();
                bank = bank + storeBetAmount;
                Console.WriteLine();
            }

            if (keepPlaying == false)
            {
                Console.WriteLine("You have decided not to make a bet.");
            }

            while (keepPlaying)
            {
                int[,] arrayGen = SlotMachineMethods.GetRandom2DArray();

                while (bank > MIN_BET_AMOUNT)
                {
                    SlotMachineInAndOutMethods.BettingLinesInstruction();
                    string betSelection = SlotMachineInAndOutMethods.BettingLinesResponse();

                    if (betSelection == "H" || betSelection == "A")
                    {
                        int numberOfRowMatches = SlotMachineMethods.RowImplementation(arrayGen);

                        int rowCounter = numberOfRowMatches;

                        if (rowCounter >= LINE_MATCH_COUNTER)
                        {
                            double increaseRowBetAmount = bank + rowCounter;
                            SlotMachineInAndOutMethods.PrintBetAmountIncrease(increaseRowBetAmount);
                        }

                        if (rowCounter < LINE_MATCH_COUNTER)
                        {
                            double decreaseRowBetAmount = bank - rowCounter;
                            SlotMachineInAndOutMethods.PrintBetAmountDecrease(decreaseRowBetAmount);
                        }
                    }
                    Console.WriteLine();


                    if (betSelection == "V" || betSelection == "A")
                    {
                        int numberOfColumnMatches = SlotMachineMethods.ColumnImplementation(arrayGen);

                        int columnCounter = numberOfColumnMatches;

                        if (columnCounter >= LINE_MATCH_COUNTER)
                        {
                            double increaseColumnBetAmount = bank + columnCounter;
                            SlotMachineInAndOutMethods.PrintBetAmountIncrease(increaseColumnBetAmount);
                        }

                        if (columnCounter < LINE_MATCH_COUNTER)
                        {
                            double decreaseColumnBetAmount = bank - columnCounter;
                            SlotMachineInAndOutMethods.PrintBetAmountDecrease(decreaseColumnBetAmount);
                        }
                    }
                    Console.WriteLine();

                    if (betSelection == "D")
                    {
                        int numberOfDiagonalMatches = SlotMachineMethods.DiagonalImplementation(arrayGen);
                        int diagonalCounter = numberOfDiagonalMatches;

                        if (diagonalCounter >= LINE_MATCH_COUNTER)
                        {
                            double increaseDiagonalBetAmount = bank + diagonalCounter;
                            SlotMachineInAndOutMethods.PrintBetAmountIncrease(increaseDiagonalBetAmount);
                        }

                        if (diagonalCounter < LINE_MATCH_COUNTER)
                        {
                            double decreaseDiagonalBetAmount = bank - diagonalCounter;
                            SlotMachineInAndOutMethods.PrintBetAmountDecrease(decreaseDiagonalBetAmount);
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}

