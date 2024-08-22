using System.ComponentModel.Design;

namespace Slot_machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //lets specify the size of the grid, 3x3 or 5x5 etc...
            const int SIZE = 3;

            //this is for the random number generator:
            const int MIN_NUMBER = 1;
            const int MAX_NUMBER = 10;

            //game modes
            const string CENTER_LINE_GAME_OPTION = "C";
            const string HORIZONTAL_LINE_GAME_OPTION = "H";
            const string VERTICAL_LINE_GAME_OPTION = "V";
            const string DIAGONAL_LINE_GAME_OPTION = "D";

            //specify the possibilities:
            const string INSTRUCTION = "Please select the game mode below!" +
                "\r\nFor Center lines press button C" +
                "\r\nFor All horizontal lines press button H" +
                "\r\nFor All vertical lines press button V" +
                "\r\nFor All diagonal lines press button D";

            //specify the details about winning and losing money:
            const int WIN = 5;
            const int LOSE = 1;
            string INSTR_FOR_MONEY = $"For every winning line you will earn ${WIN}!" +
                $"\r\nFor every losing line you will lose ${LOSE}!" +
                $"\r\nHow much money would you like to add? Please, type the amount in dollars: ";

            //creating a 2D array with the desired number of items:
            int[,] grid = new int[SIZE, SIZE];

            //defining the random number
            Random random = new Random();

            //r = rows, first number in the definition of the 2D array
            //c = columns, second number
            int c = 0;
            int r = 0;

            //create an int to keep track of balance:
            Console.WriteLine(INSTR_FOR_MONEY);
            int balance = Convert.ToInt32(Console.ReadLine());

            do
            { 
                //adding random elements to the 2D array:
                for (r = 0; r < SIZE; r++)
                {
                    for (c = 0; c < SIZE; c++)
                    {
                        //lets define a random number between 1 and 9
                        int randomNumber = random.Next(MIN_NUMBER, MAX_NUMBER);
                        //and now add it:
                        grid[r, c] = randomNumber;
                    }
                }

                Console.WriteLine(INSTRUCTION);
                string gameMode = Console.ReadLine().ToUpper();

                //Lets print our grid but in a nice way, every row in a different line:
                for (r = 0; r < SIZE; r++)
                {
                    for (c = 0; c < SIZE; c++)
                    {
                        Console.Write(grid[r, c]);
                    }
                    Console.Write($"\r\n");
                }

                if (gameMode == HORIZONTAL_LINE_GAME_OPTION)  // horizontal lines:
                {
                    for (r = 0; r < SIZE; r++)
                    {
                        int count = 0;
                        for (c = 0; c < SIZE - 1; c++)
                        {
                            if (grid[r, c] != grid[r, c + 1]) //as soon as we have a mismatch, we break the loop and move to the next row
                            {
                                balance-=LOSE;
                                Console.WriteLine($"The {r + 1}. horizontal row did not win!");
                                break;
                            }
                            if (grid[r, c] == grid[r, c + 1]) //if there is a match somewhere in the row:
                            {
                                count++;
                                if (count == SIZE - 1)
                                {
                                    balance+=WIN;
                                    Console.Write($"You win! There is a match in the {r + 1}. horizontal row: ");
                                    for (int x = 0; x < SIZE; x++)
                                    {
                                        Console.Write(grid[r, x]);
                                    }
                                    Console.WriteLine($"\r");
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                    }
                    Console.WriteLine($"Your current balance is: ${balance}");
                }

                if (gameMode == VERTICAL_LINE_GAME_OPTION)  // vertical lines:
                {
                    for (c = 0; c < SIZE; c++)
                    {
                        int count = 0;
                        for (r = 0; r < SIZE - 1; r++)
                        {
                            if (grid[r, c] != grid[r + 1, c]) //as soon as we have a mismatch, we break the loop and move to the next row
                            {
                                balance -= LOSE;
                                Console.WriteLine($"The {c + 1}. vertical line did not win!");
                                break;
                            }
                            if (grid[r, c] == grid[r + 1, c]) //if there is a match somewhere in the column:
                            {
                                count++;
                                if (count == SIZE - 1)
                                {
                                    balance += WIN;
                                    Console.Write($"You win! There is a match in the {c + 1}. vertical line: ");
                                    for (int x = 0; x < SIZE; x++)
                                    {
                                        Console.Write(grid[x, c]);
                                    }
                                    Console.WriteLine($"\r");
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                    }
                    Console.WriteLine($"Your current balance is: ${balance}");
                }

                if (gameMode == CENTER_LINE_GAME_OPTION)  // center lines:
                {
                    int m = SIZE / 2; //for defining the middle element of the row/column

                    //for the vertical center line:
                    int count = 0;
                    for (r = 0; r < SIZE - 1; r++)
                    {
                        if (grid[r, m] != grid[r + 1, m])
                        {
                            balance -= LOSE;
                            Console.WriteLine($"The vertical center line did not win!");
                            break;
                        }
                        if (grid[r, m] == grid[r + 1, m])
                        {
                            count++;
                            if (count == SIZE - 1)
                            {
                                balance += WIN;
                                Console.Write($"You win! There is a match in the vertical center line: ");
                                for (int x = 0; x < SIZE; x++)
                                {
                                    Console.Write(grid[x, m]);
                                }
                                Console.WriteLine($"\r");
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    //for the horizontal center line:
                    count = 0;
                    for (c = 0; c < SIZE - 1; c++)
                    {
                        if (grid[m, c] != grid[m, c + 1])
                        {
                            balance -= LOSE;
                            Console.WriteLine($"The horizontal center line did not win!");
                            break;
                        }
                        if (grid[m, c] == grid[m, c + 1])
                        {
                            count++;
                            if (count == SIZE - 1)
                            {
                                balance += WIN;
                                Console.Write($"You win! There is a match in the horizontal center line: ");
                                for (int x = 0; x < SIZE; x++)
                                {
                                    Console.Write(grid[m, x]);
                                }
                                Console.WriteLine($"\r");
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    Console.WriteLine($"Your current balance is: ${balance}");
                }

                if (gameMode == DIAGONAL_LINE_GAME_OPTION)  // diagonal lines:
                {
                    c = 0;
                    int count = 0;
                    for (r = 0; r < SIZE - 1; r++) //for diagonal line top left to bottom right
                    {
                        if (grid[r, c] != grid[r + 1, c + 1])
                        {
                            balance -= LOSE;
                            Console.WriteLine($"The first diagonal line did not win!");
                            break;
                        }
                        if (grid[r, c] == grid[r + 1, c + 1])
                        {
                            count++;
                            if (count == SIZE - 1)
                            {
                                balance += WIN;
                                Console.Write($"You win! There is a match in the first diagonal line: ");
                                for (int x = 0; x < SIZE; x++)
                                {
                                    Console.Write(grid[x, x]);
                                }
                                Console.WriteLine($"\r");
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    count = 0;
                    c = SIZE;
                    for (r = 0; r < SIZE - 1; r++) //for diagonal line top right to bottom left
                    {
                        c--;
                        if (grid[r, c] != grid[r + 1, c - 1])
                        {
                            balance -= LOSE;
                            Console.WriteLine($"The second diagonal line did not win!");
                            break;
                        }
                        if (grid[r, c] == grid[r + 1, c - 1])
                        {
                            count++;
                            if (count == SIZE - 1)
                            {
                                balance += WIN;
                                Console.Write($"You win! There is a match in the second diagonal line: ");
                                int y = 0;
                                for (int x = SIZE - 1; x >= 0; x--)
                                {
                                    Console.Write(grid[y, x]);
                                    y++;
                                }
                                Console.WriteLine($"\r");
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    Console.WriteLine($"Your current balance is: ${balance}");
                }

                if (balance <= 0)
                {
                    Console.WriteLine("You lost all your money!");
                    break;
                }

                //possibility to get out with your current balance:
                Console.WriteLine("\r\nDo you want to keep playing? \r\nPress Y for Yes and N for No!");
                string yes = "Y";
                string no = "N";
                string decision = Console.ReadLine().ToUpper();
                if (decision == yes)
                {
                    //clear the screen before moving on to the next round
                    Console.WriteLine("\r\nPlease press any button to move on to the next round!");
                    Console.ReadKey();
                    Console.Clear();
                }
                if (decision == no)
                {
                    Console.WriteLine($"Thank you for playing!\r\nYour balance is: ${balance}!\r\nGoodbye!");
                    break;
                }
            } while (balance > 0);
        }
    }
}
