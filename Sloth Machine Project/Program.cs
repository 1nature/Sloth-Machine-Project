using Sloth_Machine_Project;

namespace Refactored_Slot_Machine
{
    internal class Program
    {
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
                bank = UIMethods.GetBetAmount();
                UIMethods.WriteEmptyLine();
            }
            else
            {
                Console.WriteLine("You have decided not to make a bet.");
            }

            while (keepPlaying)
            {
                int[,] arrayGen = LogicMethods.GetRandom2DArray(); //{ { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 } }; //{ { 1, 1, 1 }, { 2, 2, 2 }, { 3, 3, 3 } };
                UIMethods.Print2DArray(arrayGen);

                while (bank > Constants.MIN_BET_AMOUNT)
                {
                    UIMethods.ShowBettingLinesInstruction();
                    char betSelection = UIMethods.GetBettingLinesResponse();

                    if (betSelection == Constants.LINE_TYPE_HOR || betSelection == Constants.LINE_TYPE_ALL)
                    {
                        int numberOfRowMatches = LogicMethods.CheckHorizontalLinesWinning(arrayGen);
                        bank = bank + LogicMethods.CheckOnWinningAmount(numberOfRowMatches);

                        if (numberOfRowMatches >= Constants.LINE_MATCH_COUNTER)
                        {
                            UIMethods.PrintBetAmountIncrease(bank);
                        }
                        else
                        {
                            UIMethods.PrintBetAmountDecrease(bank);
                        }
                    }
                    UIMethods.WriteEmptyLine();


                    if (betSelection == Constants.LINE_TYPE_VER || betSelection == Constants.LINE_TYPE_ALL)
                    {
                        int numberOfColumnMatches = LogicMethods.CheckVerticalLinesWinning(arrayGen);
                        bank = bank + LogicMethods.CheckOnWinningAmount(numberOfColumnMatches);

                        if (numberOfColumnMatches >= Constants.LINE_MATCH_COUNTER)
                        {
                            UIMethods.PrintBetAmountIncrease(bank);
                        }
                        else
                        {
                            UIMethods.PrintBetAmountDecrease(bank);
                        }
                    }
                    UIMethods.WriteEmptyLine();

                    if (betSelection == Constants.LINE_TYPE_DIA || betSelection == Constants.LINE_TYPE_ALL)
                    {
                        int firstDiagonalMatches = LogicMethods.CheckDiagonalOneLineWinning(arrayGen);
                        bank = bank + LogicMethods.CheckOnWinningAmount(firstDiagonalMatches);

                        if (firstDiagonalMatches >= Constants.LINE_MATCH_COUNTER)
                        {
                            UIMethods.PrintBetAmountIncrease(bank);
                        }
                        else
                        {
                            UIMethods.PrintBetAmountDecrease(bank);
                        }
                    }
                    UIMethods.WriteEmptyLine();

                    if (betSelection == Constants.LINE_TYPE_DIA || betSelection == Constants.LINE_TYPE_ALL)
                    {
                        int secondDiagonalMatches = LogicMethods.CheckDiagonalTwoLineWinning(arrayGen);
                        bank = bank + LogicMethods.CheckOnWinningAmount(secondDiagonalMatches);
                        
                        if (secondDiagonalMatches >= Constants.LINE_MATCH_COUNTER)
                        {
                            UIMethods.PrintBetAmountIncrease(bank);
                        }
                        else
                        {
                            UIMethods.PrintBetAmountDecrease(bank);
                        }
                    }
                    UIMethods.WriteEmptyLine();
                }

                if (bank <= Constants.MIN_BET_AMOUNT)
                {
                    keepPlaying = UIMethods.MakeAnotherBet();

                    if (keepPlaying)
                    {
                        bank = UIMethods.GetBetAmount();
                        UIMethods.WriteEmptyLine();
                    }
                    else
                    {
                        keepPlaying = false;
                        Environment.Exit(0);
                    }

                }
            }
        }
    }
}

