using System;
using System.Threading;
using System.Timers;

namespace TetrisSecTry
{
    class Program
    {
        private static System.Timers.Timer _timer;
        static void Main(string[] args)
        {
            Console.SetWindowSize(Field.Width, Field.Height);
            Console.SetBufferSize(Field.Width, Field.Height);  

            FigureGenerator generator = new FigureGenerator(Field.Width / 2, 0, Drawer.DEFAULT_SYMBOL);
            Figure currentFigure = generator.GetNewFigure();

            while (true)
            {                
                if (Console.KeyAvailable)
                {
                    SetTimer();
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
                Field.TryDeleteLine();
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
                case ConsoleKey.Spacebar:
                    return fig.TryRotate();                
            }
            return Result.SUCCESS;
        }

        private static void SetTimer()
        {
            _timer = new System.Timers.Timer(1500);
            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e, Figure fig)
        {
            fig.TryMove(Directions.DOWN);
        }

    }
}
