using Sloth_Machine_Project;
using System.Runtime.CompilerServices;

namespace Refactored_Slot_Machine
{
    internal class Program
    {
        const int MIN_BET_AMOUNT = 1;
        const int LINE_MATCH_COUNTER = 1;
        public const int BET_REDUCTION = 3;
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
                bank = UIMethods.GetBetAmount();
                UIMethods.WriteEmptyLine();
            }

            else
            {
                Console.WriteLine("You have decided not to make a bet.");
            }

            while (keepPlaying)
            {
                int[,] arrayGen = { { 1, 2, 1 }, { 1, 1, 1 }, { 1, 1, 1 } }; //TODO: LogicMethods.GetRandom2DArray();
                UIMethods.Print2DArray(arrayGen);

                while (bank > MIN_BET_AMOUNT)
                {
                    UIMethods.BettingLinesInstruction();
                    char betSelection = UIMethods.BettingLinesResponse();

                    if (betSelection == LINE_TYPE_HOR || betSelection == LINE_TYPE_ALL)
                    {
                        int numberOfRowMatches = LogicMethods.RowImplementation(arrayGen);

                        
                        if (numberOfRowMatches >= LINE_MATCH_COUNTER)
                        {
                            bank = bank + numberOfRowMatches;
                            UIMethods.PrintBetAmountIncrease(bank);
                        }

                        else
                        {
                            bank = bank - BET_REDUCTION;
                            UIMethods.PrintBetAmountDecrease(bank);
                        }
                    }
                    UIMethods.WriteEmptyLine();


                    if (betSelection == LINE_TYPE_VER || betSelection == LINE_TYPE_ALL)
                    {
                        int numberOfColumnMatches = LogicMethods.ColumnImplementation(arrayGen);

                        if (numberOfColumnMatches >= LINE_MATCH_COUNTER)
                        {
                            bank = bank + numberOfColumnMatches;
                            UIMethods.PrintBetAmountIncrease(bank);
                        }

                        else
                        {
                            bank = bank - BET_REDUCTION;
                            UIMethods.PrintBetAmountDecrease(bank);
                        }
                    }
                    UIMethods.WriteEmptyLine();

                    if (betSelection == LINE_TYPE_DIA)
                    {
                        int numberOfDiagonalMatches = LogicMethods.DiagonalImplementation(arrayGen);

                        if (numberOfDiagonalMatches >= LINE_MATCH_COUNTER)
                        {
                            bank = bank + numberOfDiagonalMatches;
                            UIMethods.PrintBetAmountIncrease(bank);
                        }

                        else
                        {
                            bank = bank - LINE_MATCH_COUNTER;
                            UIMethods.PrintBetAmountDecrease(bank);
                        }
                    }
                    UIMethods.WriteEmptyLine();
                }

                if (bank <= MIN_BET_AMOUNT)
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

