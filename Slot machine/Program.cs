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
            const string CL = "Center lines";
            const string H = "All horizontal lines";
            const string V = "All vertical lines";
            const string D = "All diagonal lines";

            //specify the possibilities:
            const string INSTRUCTION = $"Please select the game mode below!" +
                $"\r\nFor {CL} press button C" +
                $"\r\nFor {H} press button H" +
                $"\r\nFor {V} press button V" +
                $"\r\nFor {D} press button D";

            //creating a 2D array with the desired number of items:
            //int[,] table = new int[SIZE, SIZE]
            int[,] table = { { 1, 2, 1 }, { 2, 1, 2 }, { 1, 2, 1 } };

            //defining the random number
            Random random = new Random();

            //r = rows, first number in the definition of the 2D array
            //c = columns, second number
            int c = 0;
            int r = 0;

            ////adding random elements to the 2D array:
            //for (r = 0; r < SIZE; r++)
            //{
            //    for (c = 0; c < SIZE; c++)
            //    {
            //        //lets define a random number between 1 and 9
            //        int randomNumber = random.Next(MIN_NUMBER, MAX_NUMBER);
            //        //and now add it:
            //        table[r, c] = randomNumber;
            //    }
            //}

            Console.WriteLine(INSTRUCTION);
            string answer = Console.ReadLine().ToUpper();

            //Lets print our grid but in a nice way, every row in a different line:
            for (r = 0; r < SIZE; r++)
            {
                for (c = 0; c < SIZE; c++)
                {
                    Console.Write(table[r, c]);
                }
                Console.Write($"\r\n");
            }

            if (answer == "H")  // horizontal lines:
            {
                for (r = 0; r < SIZE; r++)
                {
                    int count = 0;
                    for (c = 0; c < SIZE - 1; c++)
                    {
                        if (table[r, c] != table[r, c + 1]) //as soon as we have a mismatch, we break the loop and move to the next row
                        {
                            Console.WriteLine($"The {r + 1}. horizontal row did not win!");
                            break;
                        }
                        if (table[r, c] == table[r, c + 1]) //if there is a match somewhere in the row:
                        {
                            count++;
                            if (count == SIZE - 1)
                            {
                                Console.Write($"You win! There is a match in the {r + 1}. horizontal row: ");
                                for (int x = 0; x < SIZE; x++)
                                {
                                    Console.Write(table[r, x]);
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
            }

            if (answer == "V")  // vertical lines:
            {
                for (c = 0; c < SIZE; c++)
                {
                    int count = 0;
                    for (r = 0; r < SIZE - 1; r++)
                    {
                        if (table[r, c] != table[r + 1, c]) //as soon as we have a mismatch, we break the loop and move to the next row
                        {
                            Console.WriteLine($"The {c + 1}. vertical line did not win!");
                            break;
                        }
                        if (table[r, c] == table[r + 1, c]) //if there is a match somewhere in the column:
                        {
                            count++;
                            if (count == SIZE - 1)
                            {
                                Console.Write($"You win! There is a match in the {c + 1}. vertical line: ");
                                for (int x = 0; x < SIZE; x++)
                                {
                                    Console.Write(table[x, c]);
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
            }

            if (answer == "C")  // center lines:
            {
                int m = SIZE / 2; //for defining the middle element of the row/column

                //for the vertical center line:
                int count = 0;
                for (r = 0; r < SIZE - 1; r++)
                {
                    if (table[r, m] != table[r + 1, m])
                    {
                        Console.WriteLine($"The vertical center line did not win!");
                        break;
                    }
                    if (table[r, m] == table[r + 1, m])
                    {
                        count++;
                        if (count == SIZE - 1)
                        {
                            Console.Write($"You win! There is a match in the vertical center line: ");
                            for (int x = 0; x < SIZE; x++)
                            {
                                Console.Write(table[x, m]);
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
                    if (table[m, c] != table[m, c + 1])
                    {
                        Console.WriteLine($"The horizontal center line did not win!");
                        break;
                    }
                    if (table[m, c] == table[m, c + 1])
                    {
                        count++;
                        if (count == SIZE - 1)
                        {
                            Console.Write($"You win! There is a match in the horizontal center line: ");
                            for (int x = 0; x < SIZE; x++)
                            {
                                Console.Write(table[m, x]);
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


            if (answer == "D")  // diagonal lines:
            {
                c = 0;
                int count = 0;
                for (r = 0; r < SIZE - 1; r++) //for diagonal line top left to bottom right
                {
                    if (table[r, c] != table[r + 1, c + 1])
                    {
                        Console.WriteLine($"The first diagonal line did not win!");
                        break;
                    }
                    if (table[r, c] == table[r + 1, c + 1])
                    {
                        count++;
                        if (count == SIZE - 1)
                        {
                            Console.Write($"You win! There is a match in the first diagonal line: ");
                            for (int x = 0; x < SIZE; x++)
                            {
                                Console.Write(table[x, x]);
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
                    if (table[r, c] != table[r + 1, c - 1])
                    {
                        Console.WriteLine($"The second diagonal line did not win!");
                        break;
                    }
                    if (table[r, c] == table[r + 1, c - 1])
                    {
                        count++;
                        if (count == SIZE - 1)
                        {
                            Console.Write($"You win! There is a match in the second diagonal line: ");
                            int y = 0;
                            for (int x = SIZE - 1; x >= 0; x--)
                            {
                                Console.Write(table[y, x]);
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
            }
        }
    }
}
