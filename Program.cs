using System;
using System.Threading;

namespace TetrisSecTry
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Field.Width, Field.Height);
            Console.SetBufferSize(Field.Width, Field.Height);           

            FigureGenerator generator = new FigureGenerator(20, 0, '#');
            Figure currentFigure = generator.GetNewFigure();

            while (true)
            {                
                if (Console.KeyAvailable)
                {
                    var pressKey = Console.ReadKey();
                    var result = MoveCurrentFigure(currentFigure, pressKey.Key);
                    ProcessResult(result, generator, ref currentFigure);                    
                }
            }
        }

        private static bool ProcessResult(Result result, FigureGenerator generator, ref Figure currentFigure)
        {
            if(result == Result.DOWN_BORDER_STRIKE || result == Result.HEAP_STRIKE)
            {
                Field.AddFigure(currentFigure);
                currentFigure = generator.GetNewFigure();
                return true;
            }
            return false;
        }

        private static Result MoveCurrentFigure(Figure fig, ConsoleKey pressKey)
        {
            switch (pressKey)
            {
                case ConsoleKey.LeftArrow:
                    return fig.TryMove(Directions.LEFT);
                case ConsoleKey.RightArrow:
                    return fig.TryMove(Directions.RIGHT);
                case ConsoleKey.DownArrow:
                    return fig.TryMove(Directions.DOWN);
                case ConsoleKey.Spacebar:
                    return fig.TryRotate();                
            }
            return Result.SUCCESS;
        }
    }
}
