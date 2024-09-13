using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slot_machine
{
    public class UserInterface
    {


        /// <summary>
        /// Getting the starting balance from the player (how many dollars they want to add)
        /// </summary>
        public static int GetBalanceFromPlayer()
        {
            Console.WriteLine($"For every winning line you will earn ${Constants.WIN}!" +
                $"\r\nFor every losing line you will lose ${Constants.LOSE}!" +
                $"\r\nHow much money would you like to add? Please, type the amount in dollars: ");
            int balance = Convert.ToInt32(Console.ReadLine());
            return balance;
        }


        /// <summary>
        /// Get the game mode from the player.
        /// </summary>
        public static string GetGameMode()
        {
            Console.WriteLine($"Please select the game mode below!" +
            $"\r\nFor Center lines press button ${Constants.CENTER_LINE_GAME_OPTION}" +
            $"\r\nFor All horizontal lines press button ${Constants.HORIZONTAL_LINE_GAME_OPTION}" +
            $"\r\nFor All vertical lines press button ${Constants.VERTICAL_LINE_GAME_OPTION}" +
            $"\r\nFor All diagonal lines press button ${Constants.DIAGONAL_LINE_GAME_OPTION}");
            string gameMode = Console.ReadLine().ToUpper();
            return gameMode;
        }

        /// <summary>
        /// Print the current state of the grid
        /// </summary>
        /// <param name="r">rows, first number in the definition of the 2D array</param>
        /// <param name="c">columns, second number</param>
        /// <param name="grid">name of the grid</param>
        /// <returns></returns>
        public static void PrintGrid(int[,] grid)
        {
            for (int r = 0; r < Constants.SIZE; r++)
            {
                for (int c = 0; c < Constants.SIZE; c++)
                {
                    Console.Write(grid[r, c]);
                }
                Console.Write($"\r\n");
            }
        }

        /// <summary>
        /// Printing the current status of the balance
        /// </summary>
        /// <param name="balance">Balance value</param>
        public static void PrintBalance(int balance)
        {
            Console.WriteLine($"Your current balance is: ${balance}");
        }

        /// <summary>
        /// Printing the message if the player won
        /// </summary>
        public static void PrintWinMessage()
        {
            Console.WriteLine($"\r\nYou have a match in this round! You won!");
        }

        /// <summary>
        /// Printing the message if the player lost
        /// </summary>
        public static void PrintLoseMessage()
        {
            Console.WriteLine($"\r\nYou have 0 matches, you lost this round!");
        }

        /// <summary>
        /// Printing the message if the player runs out of money
        /// </summary>
        public static void PrintZeroBalanceMessage()
        {
            Console.WriteLine($"\r\nYou ran out of money, you lost the game!");
        }

        /// <summary>
        /// Gets input from player if they want to stay in the game or exit with their current balance
        /// </summary>
        /// <param name="decision">player input</param>
        /// <returns></returns>
        public static string GetAnswerIfPlayerLeaves(string decision)
        {
            Console.WriteLine("\r\nDo you want to leave the game with your current balance? \r\nPress Y for Yes and N for No!");
            decision = Console.ReadLine().ToUpper();
            return decision;
        }

        /// <summary>
        /// Prints goodbye message if player wants to leave with the current balance
        /// </summary>
        /// <param name="balance">Current balance</param>
        public static void PrintExitMessage(int balance)
        {
            Console.WriteLine($"Thank you for playing!\r\nYour balance is: ${balance}!\r\nGoodbye!");
        }

        /// <summary>
        /// GEt the player to press a button to move on to the next round
        /// </summary>
        public static void PrintPressAnyButtonMessage()
        {
            Console.WriteLine("\r\nPlease press any button to move on to the next round!");
            Console.ReadKey();
        }

        /// <summary>
        /// Clear the screen before moving on to the next round
        /// </summary>
        public static void ClearScreen()
        {
            Console.Clear();
        }

    }
}
