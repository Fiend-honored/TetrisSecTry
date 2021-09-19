using System;
using System.Threading;
using System.Timers;

namespace TetrisSecTry
{
    class Program
    {
        const int TIMER_INTERVAL = 500;
        static System.Timers.Timer timer;
        private static Object _lockObject = new Object();

        static Figure currentFigure;
        static FigureGenerator generator;

        static void Main(string[] args)
        {
            Console.SetWindowSize(Field.Width, Field.Height);
            Console.SetBufferSize(Field.Width, Field.Height);  

            generator = new FigureGenerator(Field.Width / 2, 0, Drawer.DEFAULT_SYMBOL);
            currentFigure = generator.GetNewFigure();
            SetTimer();

            while (true)
            {                
                if (Console.KeyAvailable)
                {
                    
                    var pressKey = Console.ReadKey();
                    Monitor.Enter(_lockObject);
                    var result = MoveCurrentFigure(currentFigure, pressKey.Key);                    
                    ProcessResult(result, generator, ref currentFigure);
                    Monitor.Exit(_lockObject);
                }
            }
        }

        private static bool ProcessResult(Result result, FigureGenerator generator, ref Figure currentFigure)
        {
            if(result == Result.DOWN_BORDER_STRIKE || result == Result.HEAP_STRIKE)
            {
                Field.AddFigure(currentFigure);
                Field.TryDeleteLine();
                if (currentFigure.IsOnTop())
                {
                    WriteGameOver();
                    timer.Elapsed -= OnTimedEvent;
                    return true;
                }
                else
                {
                    currentFigure = generator.GetNewFigure();
                    return false;
                }                     
            }
            return false;
        }

        private static void WriteGameOver()
        {
            Console.SetCursorPosition(Field.Width / 2 - 8, Field.Height / 2);
            Console.Write("G A M E   O V E R");
        }

        private static Result MoveCurrentFigure(Figure fig, ConsoleKey pressKey)
        {
            switch (pressKey)
            {
                case ConsoleKey.DownArrow:
                    return fig.TryMove(Directions.DOWN);
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
            timer = new System.Timers.Timer(TIMER_INTERVAL);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Monitor.Enter(_lockObject);
            var result = currentFigure.TryMove(Directions.DOWN);
            ProcessResult(result, generator, ref currentFigure);
            Monitor.Exit(_lockObject);
        }

    }
}
