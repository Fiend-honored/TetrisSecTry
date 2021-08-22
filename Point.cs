using System;
using System.Collections.Generic;
using System.Text;

namespace TetrisSecTry
{
    class Point
    {
        public int x, y;
        public char c;
        private Point point;

        public Point(int a, int b, char sym)
        {
            x = a;
            y = b;
            c = sym;
        }

        public Point(Point point)
        {
            x = point.x;
            y = point.y;
            c = point.c;
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
            Console.SetCursorPosition(0, 0);
        }


        internal void Move(Directions dir)
        {
            switch (dir)
            {
                case Directions.DOWN:
                    y++;
                    break;
                case Directions.LEFT:
                    x--;
                    break;
                case Directions.RIGHT:
                    x++;
                    break;
            }
        }

        internal void Hide()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }
    }
}
