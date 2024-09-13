using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Slot_machine
{
    public class LogicalCode
    {

        /// <summary>
        /// adding random elements to the 2D array:
        /// </summary>
        /// <param name="r">rows, first number in the definition of the 2D array</param>
        /// <param name="c">columns, second number</param>
        /// <param name="grid">name of the grid</param>
        public static int[,] AddRandomNumbersToGrid(int r, int c, int[,] grid)
        {
            for (r = 0; r < Constants.SIZE; r++)
            {
                for (c = 0; c < Constants.SIZE; c++)
                {
                    //lets define a random number between 1 and 9
                    Random random = new Random();
                    int randomNumber = random.Next(Constants.MIN_NUMBER, Constants.MAX_NUMBER);
                    //and now add it:
                    grid[r, c] = randomNumber;
                }
            }
            return grid;
        }


        /// <summary>
        /// Increasing the balance in case of win
        /// </summary>
        /// <param name="balance">Balance of the player</param>
        /// <returns></returns>
        public static int IncreaseBalance(int balance)
        {
            balance += Constants.WIN;
            return balance;
        }

        /// <summary>
        /// Decreasing the balance in case of losing
        /// </summary>
        /// <param name="balance">Balance of the player</param>
        /// <returns></returns>
        public static int DecreaseBalance(int balance)
        {
            balance -= Constants.LOSE;
            return balance;
        }

        /// <summary>
        /// Checking if the player's balance is still positive
        /// </summary>
        /// <param name="balance">player's balance</param>
        /// <returns></returns>
        public static bool CheckIfPlayerHasPositiveBalance(int balance)
        {
            if (balance > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checking if the player wants to get out with their current balance
        /// </summary>
        /// <param name="decision">Input from player</param>
        /// <returns></returns>
        public static bool CheckIfPlayerWantsToLeave(string decision)
        {
            string yes = "Y";
            if (decision == yes)
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// Checking for general win (consolidates all 4 methods in 1)
        /// </summary>
        /// <param name="gameMode">Game mode got from the player</param>
        /// <returns></returns>
        public static bool CheckForWin(string gameMode, int[,] grid)
        {
            bool CheckForWin = false;
            if (gameMode == Constants.HORIZONTAL_LINE_GAME_OPTION)
            {
                CheckForWin = CheckForHorizontalWin(grid);
            }
            if (gameMode == Constants.VERTICAL_LINE_GAME_OPTION)
            {
                CheckForWin = CheckForVerticalWin(grid);
            }
            if (gameMode == Constants.CENTER_LINE_GAME_OPTION)
            {
                CheckForWin = CheckForCenterLineWin(grid);
            }
            if (gameMode == Constants.DIAGONAL_LINE_GAME_OPTION)
            {
                CheckForWin = CheckForDiagonalWin(grid);
            }

            if (CheckForWin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Checking for a match in horizontal lines.
        /// </summary>
        /// <param name="r">rows, first number in the definition of the 2D array</param>
        /// <param name="c">columns, second number</param>
        /// <param name="grid">name of the grid</param>
        /// <param name="balance">balance got from the player</param>
        /// <returns></returns>
        public static bool CheckForHorizontalWin(int[,] grid)
        {
            bool CheckForHorizontalWin = false;
            for (int r = 0; r < Constants.SIZE; r++)
            {
                int count = 0;
                for (int c = 0; c < Constants.SIZE - 1; c++)
                {
                    if (grid[r, c] != grid[r, c + 1]) //as soon as we have a mismatch, we break the loop and move to the next row
                    {
                        CheckForHorizontalWin = false;
                        break;
                    }
                    if (grid[r, c] == grid[r, c + 1]) //if there is a match somewhere in the row:
                    {
                        count++;
                        if (count == Constants.SIZE - 1)
                        {
                            CheckForHorizontalWin = true;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                if (CheckForHorizontalWin)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checking for a match in vertical lines.
        /// </summary>
        /// <param name="r">rows, first number in the definition of the 2D array</param>
        /// <param name="c">columns, second number</param>
        /// <param name="grid">name of the grid</param>
        /// <param name="balance">balance got from the player</param>
        /// <returns></returns>
        public static bool CheckForVerticalWin(int[,] grid)
        {
            bool CheckForVerticalWin = false;
            for (int c = 0; c < Constants.SIZE; c++)
            {
                int count = 0;
                for (int r = 0; r < Constants.SIZE - 1; r++)
                {
                    if (grid[r, c] != grid[r + 1, c]) //as soon as we have a mismatch, we break the loop and move to the next row
                    {
                        CheckForVerticalWin = false;
                        break;
                    }
                    if (grid[r, c] == grid[r + 1, c]) //if there is a match somewhere in the column:
                    {
                        count++;
                        if (count == Constants.SIZE - 1)
                        {
                            CheckForVerticalWin = true;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                if (CheckForVerticalWin)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checking for a match in center lines.
        /// </summary>
        /// <param name="r">rows, first number in the definition of the 2D array</param>
        /// <param name="c">columns, second number</param>
        /// <param name="grid">name of the grid</param>
        /// <param name="balance">balance got from the player</param>
        /// <returns></returns>
        public static bool CheckForCenterLineWin(int[,] grid)
        {
            bool checkForCenterLineWin = false;

            int m = Constants.SIZE / 2; //for defining the middle element of the row/column
            
            //for the vertical center line:
            int count = 0;
            for (int r = 0; r < Constants.SIZE - 1; r++)
            {
                if (grid[r, m] != grid[r + 1, m])
                {
                    break;
                }
                if (grid[r, m] == grid[r + 1, m])
                {
                    count++;
                    if (count == Constants.SIZE - 1)
                    {
                        checkForCenterLineWin = true;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            //for the horizontal center line:
            count = 0;
            for (int c = 0; c < Constants.SIZE - 1; c++)
            {
                if (grid[m, c] != grid[m, c + 1])
                {
                    break;
                }
                if (grid[m, c] == grid[m, c + 1])
                {
                    count++;
                    if (count == Constants.SIZE - 1)
                    {
                        checkForCenterLineWin = true;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            if (checkForCenterLineWin)
            {
                return true;
            }
            else
            {  
                return false; 
            }
        }

        /// <summary>
        /// Checking for a match in diagonal lines.
        /// </summary>
        /// <param name="r">rows, first number in the definition of the 2D array</param>
        /// <param name="c">columns, second number</param>
        /// <param name="grid">name of the grid</param>
        /// <param name="balance">balance got from the player</param>
        /// <returns></returns>
        public static bool CheckForDiagonalWin(int[,] grid)
        {
            bool checkForDiagonalWin = false;
            int count = 0;
            int c = 0;
            for (int r = 0; r < Constants.SIZE - 1; r++) //for diagonal line top left to bottom right
            {
                if (grid[r, c] != grid[r + 1, c + 1])
                {
                    break;
                }
                if (grid[r, c] == grid[r + 1, c + 1])
                {
                    count++;
                    if (count == Constants.SIZE - 1)
                    {
                        checkForDiagonalWin = true;
                    }
                    else
                    {
                        c++;
                        continue;
                    }
                }
            }
            count = 0;
            c = Constants.SIZE;
            for (int r = 0; r < Constants.SIZE - 1; r++) //for diagonal line top right to bottom left
            {
                c--;
                if (grid[r, c] != grid[r + 1, c - 1])
                {
                    break;
                }
                if (grid[r, c] == grid[r + 1, c - 1])
                {
                    count++;
                    if (count == Constants.SIZE - 1)
                    {
                        checkForDiagonalWin = true;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            if (checkForDiagonalWin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
