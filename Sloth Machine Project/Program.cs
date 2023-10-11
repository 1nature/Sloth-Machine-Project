using Sloth_Machine_Project;
namespace Refactored_Slot_Machine
{
    internal class Program
    {
        const int MIN_BET_AMOUNT = 1;

        static void Main(string[] args)
        {
            bool keepPlaying = true;
            double bank = 0;

            SlotMachineMethods.ShowWelcomeToTheGame();
            SlotMachineMethods.ShowGameDescription();
            bool wantsToBet = SlotMachineMethods.MakeBetDecision();

            if(wantsToBet)
            {
                //something happens
                bank = bank + SlotMachineMethods.GetBetAmount();

            }
            else
            {
                //something else happnes
            }

            while (keepPlaying)
            {
                int[,] arrayGen = SlotMachineMethods.GetRandom2DArray();
                SlotMachineMethods.MakeAnotherBet();

                while (SlotMachineMethods.GetBetAmount() > MIN_BET_AMOUNT)
                {
                    SlotMachineMethods.BettingLinesInstruction();
                    string betSelection = SlotMachineMethods.BettingLinesResponse();

                    if (betSelection == "H" || betSelection == "A")
                    {
                        SlotMachineMethods.RowImplementation();
                        SlotMachineMethods.RowWinOrLossCondition();
                        //SlotMachineMethods.PromptBetAmountIncrease();
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

                if (SlotMachineMethods.GetBetAmount() < MIN_BET_AMOUNT)
                {
                    SlotMachineMethods.MakeAnotherBet();
                }
            }
        }
    }
}

