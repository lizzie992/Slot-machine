using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slot_machine
{
    public static class Constants
    {
        //lets specify the size of the grid, 3x3 or 5x5 etc...
        public const int SIZE = 3;

        //this is for the random number generator:
        public const int MIN_NUMBER = 1;
        public const int MAX_NUMBER = 10;

        //game modes
        public const string CENTER_LINE_GAME_OPTION = "C";
        public const string HORIZONTAL_LINE_GAME_OPTION = "H";
        public const string VERTICAL_LINE_GAME_OPTION = "V";
        public const string DIAGONAL_LINE_GAME_OPTION = "D";

        //specify the details about winning and losing money:
        public const int WIN = 5;
        public const int LOSE = 1;
    }
}
