using System;
using System.Collections.Generic;
using System.Text;

namespace TetrisSecTry
{
    abstract class Figure
    {
        const int LENGTH = 4;

        public Point[] points = new Point[LENGTH];

        public void Draw()
        {
            foreach (Point p in points)
            {
                p.Draw();
            }
        }

        internal Result TryMove(Directions dir)
        {
            Hide();
            var clone = Clone();
            Move(clone, dir);

            var result = VerifiPosition(clone);
            if ()
            Draw();
        }
        internal void TryRotate()
        {
            Hide();
            var clone = Clone();
            Rotate(clone);
            if (VerifiPosition(clone))
                points = clone;
            Draw();
        }

        private Result VerifiPosition(Point[] pList)
        {
            foreach(var p in pList)
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

        private void Move(Point[] pList, Directions dir)
        {
            foreach(var p in pList)
            {
                p.Move(dir);
            }
        }

        private Point[] Clone()
        {
            var newPoints = new Point[LENGTH];
            for(int i = 0; i < LENGTH; i++)
            {
                newPoints[i] = new Point(points[i]);
            }
            return newPoints;
        }

        public void Hide()
        {
            foreach(Point p in points)
            {
                p.Hide();
            }
        }

        public abstract void Rotate(Point[] pList);


    }
}
