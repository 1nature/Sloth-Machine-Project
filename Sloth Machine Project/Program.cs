using Sloth_Machine_Project;
using System.Diagnostics.Metrics;

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
                            SlotMachineMethods.PromptBetAmountIncrease(increaseRowBetAmount);
                            Console.WriteLine("You have produced at least a winning row combination");
                            Console.WriteLine($"Your row only bet amount has increased to: ${increaseRowBetAmount}");
                        }

                        if (rowCounter < LINE_MATCH_COUNTER)
                        {
                            double decreaseRowBetAmount = bank - rowCounter;
                            SlotMachineMethods.PromptBetAmountDecrease(decreaseRowBetAmount);
                            Console.WriteLine("You have not produced a winning row combination");
                            Console.WriteLine($"Your row only bet amount has reduced to: ${decreaseRowBetAmount}");
                        }
                    }
                    Console.WriteLine();


                    if (betSelection == "V" || betSelection == "A") //
                    {
                        int numberOfColumnMatches = SlotMachineMethods.ColumnImplementation(arrayGen);

                        int columnCounter = numberOfColumnMatches;
                        double increaseColumnBetAmount = bank + columnCounter;
                        double decreaseColumnBetAmount = bank - columnCounter;

                        if (columnCounter >= LINE_MATCH_COUNTER)
                        {
                            //double increaseColumnBetAmount = bank + columnCounter;
                            SlotMachineMethods.PromptBetAmountIncrease(increaseColumnBetAmount);
                            Console.WriteLine("You have produced at least a winning row combination");
                            Console.WriteLine($"Your column only bet amount has increased to: ${increaseColumnBetAmount}");
                        }

                        if (columnCounter < LINE_MATCH_COUNTER)
                        {
                            //double decreaseColumnBetAmount = bank - columnCounter;
                            SlotMachineMethods.PromptBetAmountIncrease(decreaseColumnBetAmount);
                            Console.WriteLine("You have not produced a winning row combination");
                            Console.WriteLine($"Your row only bet amount has reduced to: ${decreaseColumnBetAmount}");
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
                            SlotMachineMethods.PromptBetAmountIncrease(increaseDiagonalBetAmount);
                            Console.WriteLine("You have produced at least a winning row combination");
                            Console.WriteLine($"Your diagonal only bet amount has increased to: ${increaseDiagonalBetAmount}");
                        }

                        if (diagonalCounter < LINE_MATCH_COUNTER)
                        {
                            double decreaseDiagonalBetAmount = bank - diagonalCounter;
                            SlotMachineMethods.PromptBetAmountIncrease(decreaseDiagonalBetAmount);
                            Console.WriteLine("You have not produced a winning row combination");
                            Console.WriteLine($"Your diagonal only bet amount has reduced to: ${decreaseDiagonalBetAmount}");
                        }
                    }
                    Console.WriteLine();
                }

                //if (bank < MIN_BET_AMOUNT)
                //{
                //    SlotMachineMethods.MakeAnotherBet();
                //}
            }
        }
    }
}

