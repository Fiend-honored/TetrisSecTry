using System;
using System.Threading;

namespace TetrisSecTry
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 30);
            Console.SetBufferSize(40, 30);

            FigureGenerator generator = new FigureGenerator(20, 0, '#');
            Figure currentFigure = generator.GetNewFigure();

            while (true)
            {                
                if (Console.KeyAvailable)
                {
                    var pressKey = Console.ReadKey();
                    MoveCurrentFigure(currentFigure, pressKey);
                }
            }
        }

        private static void MoveCurrentFigure(Figure currentFigure, ConsoleKeyInfo pressKey)
        {
            switch (pressKey.Key)
            {
                case ConsoleKey.LeftArrow:
                    currentFigure.TryMove(Directions.LEFT);
                    break;
                case ConsoleKey.RightArrow:
                    currentFigure.TryMove(Directions.RIGHT);
                    break;
                case ConsoleKey.DownArrow:
                    currentFigure.TryMove(Directions.DOWN);
                    break;
                case ConsoleKey.Spacebar:
                    currentFigure.TryRotate();
                    break;
                default:
                    break;
            }
        }
    }
}
