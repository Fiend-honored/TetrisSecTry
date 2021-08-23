using System;

namespace TetrisSecTry
{
    internal class FigureGenerator
    {
        private int X { get; set; }
        private int Y { get; set; }
        private char C { get; set; }
        Random _rand = new Random();

        public FigureGenerator(int x, int y, char c)
        {
            X = x;
            Y = y;
            C = c;
        }

        public Figure GetNewFigure()
        {
            if(_rand.Next(0,2) == 0)
            {
                return new Square(X, Y, C);
            } else
            {
                return new Stick(X, Y, C);
            }
        }
    }
}