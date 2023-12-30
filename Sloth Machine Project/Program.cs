using Sloth_Machine_Project;
using System.Runtime.CompilerServices;

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


                        if (numberOfRowMatches >= Constants.LINE_MATCH_COUNTER)
                        {
                            bank = bank + numberOfRowMatches;
                            UIMethods.PrintBetAmountIncrease(bank);
                        }
                        else
                        {
                            bank = bank - Constants.BET_REDUCTION;
                            UIMethods.PrintBetAmountDecrease(bank);
                        }
                    }
                    UIMethods.WriteEmptyLine();


                    if (betSelection == Constants.LINE_TYPE_VER || betSelection == Constants.LINE_TYPE_ALL)
                    {
                        int numberOfColumnMatches = LogicMethods.CheckVerticalLinesWinning(arrayGen);

                        if (numberOfColumnMatches >= Constants.LINE_MATCH_COUNTER)
                        {
                            bank = bank + numberOfColumnMatches;
                            UIMethods.PrintBetAmountIncrease(bank);
                        }
                        else
                        {
                            bank = bank - Constants.BET_REDUCTION;
                            UIMethods.PrintBetAmountDecrease(bank);
                        }
                    }
                    UIMethods.WriteEmptyLine();

                    if (betSelection == Constants.LINE_TYPE_DIA || betSelection == Constants.LINE_TYPE_ALL)
                    {
                        int firstDiagonalMatches = LogicMethods.CheckDiagonalOneLineWinning(arrayGen);

                        if (firstDiagonalMatches >= Constants.LINE_MATCH_COUNTER)
                        {
                            bank = bank + firstDiagonalMatches;
                            UIMethods.PrintBetAmountIncrease(bank);
                        }
                        else
                        {
                            bank = bank - Constants.LINE_MATCH_COUNTER;
                            UIMethods.PrintBetAmountDecrease(bank);
                        }
                    }
                    UIMethods.WriteEmptyLine();

                    if (betSelection == Constants.LINE_TYPE_DIA || betSelection == Constants.LINE_TYPE_ALL)
                    {
                        int secondDiagonalMatches = LogicMethods.CheckDiagonalTwoLineWinning(arrayGen);

                        if (secondDiagonalMatches >= Constants.LINE_MATCH_COUNTER)
                        {
                            bank = bank + secondDiagonalMatches;
                            UIMethods.PrintBetAmountIncrease(bank);
                        }
                        else
                        {
                            bank = bank - Constants.LINE_MATCH_COUNTER;
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

