using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFILES
{
    internal class Menu
    {
        static int Pos;
        private int min;
        private int max;

        public Menu(int pos)
        {
            Pos = pos;
            min = pos;
            max = pos + 1;

            ShowArr();
        }

        static public void Update(int pos, bool isUp)
        {
            if (isUp)
            {
                Console.SetCursorPosition(0, pos + 1);
                Console.Write("  ");
            }
            else
            {
                Console.SetCursorPosition(0, pos - 1);
                Console.Write("  ");
            }

            Pos = pos;

            ShowArr();
        }

        static void ShowArr()
        {
            Console.SetCursorPosition(0, Pos);
            Console.Write("->");
        }
    }
}
