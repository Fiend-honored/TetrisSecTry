using System;
using System.Collections.Generic;
using System.Text;

namespace TetrisSecTry
{
    abstract class Figure
    {
        const int LENGTH = 4;

        public Point[] Points = new Point[LENGTH];

        public void Draw()
        {
            foreach (Point p in Points)
            {
                p.Draw();
            }
        }

        internal Result TryMove(Directions dir)
        {
            Hide();                   

            Move(dir);

            var result = VerifiPosition();
            if (result != Result.SUCCESS)
                Move(Reverse(dir));

            Draw();

            return result;
        }

        private Directions Reverse(Directions dir)
        {
            switch (dir)
            {
                case Directions.LEFT:
                    return Directions.RIGHT;
                case Directions.RIGHT:
                    return Directions.LEFT;
                case Directions.DOWN:
                    return Directions.UP;
                case Directions.UP:
                    return Directions.DOWN;
            }
            return dir;
        }

        internal Result TryRotate()
        {
            Hide();            
            Rotate();
            var result = VerifiPosition();
            if (result != Result.SUCCESS)
                while(result != Result.SUCCESS)
                {
                    Rotate();
                    result = VerifiPosition();
                }                
            Draw();
            return result;
        }

        private Result VerifiPosition()
        {
            foreach (var p in Points)
            {
                if (p.Y >= Field.Height)
                    return Result.DOWN_BORDER_STRIKE;

                if (p.X >= Field.Width || p.X < 0 || p.Y < 0)
                    return Result.BORDER_STRIKE;

                if (Field.CheckStrike(p))
                    return Result.HEAP_STRIKE;
            }
            return Result.SUCCESS;
        }

        private void Move(Directions dir)
        {
            foreach (var p in Points)
            {
                p.Move(dir);
            }
        }

        internal bool IsOnTop()
        {
            return Points[0].Y == 0;
        }

        private Point[] Clone()
        {
            var newPoints = new Point[LENGTH];
            for (int i = 0; i < LENGTH; i++)
            {
                newPoints[i] = new Point(Points[i]);
            }
            return newPoints;
        }

        public void Hide()
        {
            foreach (Point p in Points)
            {
                p.Hide();
            }
            
        }


        public abstract void Rotate();


    }
}
