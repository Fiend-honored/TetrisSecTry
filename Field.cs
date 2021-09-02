using System;
using System.Collections.Generic;
using System.Text;

namespace TetrisSecTry
{
    class Field
    {
        private static int _width = 40;
        private static int _height = 30;


        public static int Width
        {
            get
            {
                return _width;
            }

            set
            {
                _width = value;
                Console.SetWindowSize(_width, Field.Height);
                Console.SetBufferSize(_width, Field.Height);
            }
        }
        public static int Height
        {
            get
            {
                return _height;
            }

            set
            {
                _height = value;
                Console.SetWindowSize(value, Field.Height);
                Console.SetBufferSize(value, Field.Height);
            }
        }

        private static bool[][] _heap;
        
        static Field()
        {
            _heap = new bool[Height][];
            for (int i = 0; i < Height; i++)
            {
                _heap[i] = new bool[Width];
            }
        }

        public static void AddFigure(Figure fig)
        {
            foreach(var p in fig.Points)
            {
                _heap[p.Y][p.X] = true;
            }
        }

        public static bool CheckStrike(Point p)
        {
            return _heap[p.Y][p.X];
        }

        public static int[][] CheckFullLine()
        {
            int[][] checkFullLine;
            var indexFullLine = 0;
            for(int i = 0; i < Height; i++)
            {
                indexFullLine = 0;
                for (int j = 0; j < Width; j++)
                {
                    if (_heap[i][j] == true)
                        indexFullLine++;
                    if (indexFullLine == Width)
                    {
                        checkFullLine = new int[i][];
                        for (int t = 0; t < Width; t++)
                        {
                            _heap[i][t] = false;
                            checkFullLine[i] = new int[t];
                        }
                        return checkFullLine;
                    }                    
                }                
            }
            return null;
        }

    }
}
