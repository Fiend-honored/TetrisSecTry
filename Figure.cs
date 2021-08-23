using System;
using System.Collections.Generic;
using System.Text;

namespace TetrisSecTry
{
    abstract class Figure
    {
        const int LENGTH = 4;

        protected Point[] points = new Point[LENGTH];

        public void Draw()
        {
            foreach (Point p in points)
            {
                p.Draw();
            }
        }

        internal void TryMove(Directions dir)
        {
            Hide();
            var clone = Clone();
            Move(clone, dir);
            if (VerifiPosition(clone))
            {
                points = clone;
            }
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

        private bool VerifiPosition(Point[] pList)
        {
            foreach(var p in pList)
            {
                if (p.x < 0 || p.y < 0 || p.x >= 40 || p.y >= 30)
                    return false;
            }
            return true;
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



        //public void Move(Directions dir)
        //{
        //    Hide();
        //    foreach(Point p in points)
        //    {                
        //        p.Move(dir);
        //    }
        //    Draw();
        //}

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
