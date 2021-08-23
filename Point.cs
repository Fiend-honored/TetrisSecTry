using System;
using System.Collections.Generic;
using System.Text;

namespace TetrisSecTry
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char C { get; set; }

        public Point(int a, int b, char sym)
        {
            X = a;
            Y = b;
            C = sym;
        }

        public Point(Point point)
        {
            X = point.X;
            Y = point.Y;
            C = point.C;
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(C);
            Console.SetCursorPosition(0, 0);
        }


        internal void Move(Directions dir)
        {
            switch (dir)
            {
                case Directions.DOWN:
                    Y++;
                    break;
                case Directions.LEFT:
                    X--;
                    break;
                case Directions.RIGHT:
                    X++;
                    break;
            }
        }

        internal void Hide()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }
    }
}
