using Sloth_Machine_Project;

namespace Refactored_Slot_Machine
{
    internal class Program
    {
        const int MIN_BET_AMOUNT = 1;

        static void Main(string[] args)
        {
            bool keepPlaying = true;

            SlotMachineMethods.WelcomeToTheGame();
            SlotMachineMethods.GameDescription();
            SlotMachineMethods.BetDecision();

            while (keepPlaying)
            {
                int[,] arrayGen = SlotMachineMethods.GetRandom2DArray();
                SlotMachineMethods.UserBetDecision();

                while (SlotMachineMethods.AmountPlacedOnBet() > MIN_BET_AMOUNT)
                {
                    SlotMachineMethods.BettingLinesInstruction();
                    SlotMachineMethods.BettingLinesResponse();

                    if (SlotMachineMethods.BettingLinesResponse() == "H" || SlotMachineMethods.BettingLinesResponse() == "A")
                    {
                        SlotMachineMethods.RowImplementation();
                        SlotMachineMethods.RowWinOrLossCondition();
                    }
                    Console.WriteLine();

                    if (SlotMachineMethods.BettingLinesResponse() == "V" || SlotMachineMethods.BettingLinesResponse() == "A")
                    {
                        SlotMachineMethods.ColumnImplementation();
                        SlotMachineMethods.ColumnWinOrLossCondition();
                    }
                    Console.WriteLine();

                    if (SlotMachineMethods.BettingLinesResponse() == "D")
                    {
                        SlotMachineMethods.DiagonalImplementation();
                        SlotMachineMethods.DiagonalWinOrLossCondition();
                    }
                    Console.WriteLine();
                }

                if (SlotMachineMethods.AmountPlacedOnBet() < MIN_BET_AMOUNT)
                {
                    SlotMachineMethods.UserBetDecision();
                }
            }
        }
    }
}

