﻿using System.ComponentModel.Design;

namespace Slot_machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ///int[,] grid = new int[Constants.SIZE, Constants.SIZE];
            int[,] grid = { { 3, 2, 1 }, { 4, 5, 6 }, { 1, 3, 9 } };

            int balance = 0;
            string gameMode = string.Empty;
            string decisionAboutLeaving = string.Empty;

            balance = UserInterface.GetBalanceFromPlayer();

            do
            {
                //grid = LogicalCode.AddRandomNumbersToGrid(r, c, grid);

                gameMode = UserInterface.GetGameMode();

                UserInterface.PrintGrid(grid);

                if (LogicalCode.CheckForWin(gameMode, grid))
                {
                    UserInterface.PrintWinMessage();
                    balance = LogicalCode.IncreaseBalance(balance);
                }
                if (!LogicalCode.CheckForWin(gameMode, grid))
                {
                    UserInterface.PrintLoseMessage();
                    balance = LogicalCode.DecreaseBalance(balance);
                }

                if (!LogicalCode.CheckIfPlayerHasPositiveBalance(balance))
                {
                    UserInterface.PrintZeroBalanceMessage();
                    break;
                }

                UserInterface.PrintBalance(balance);

                decisionAboutLeaving = UserInterface.GetAnswerIfPlayerLeaves(decisionAboutLeaving);
                if (LogicalCode.CheckIfPlayerWantsToLeave(decisionAboutLeaving))
                {
                    UserInterface.PrintExitMessage(balance);
                    break;
                }

                UserInterface.PrintWinMessage();
                UserInterface.ClearScreen();

            } while (LogicalCode.CheckIfPlayerHasPositiveBalance(balance));
        }
    }
}
