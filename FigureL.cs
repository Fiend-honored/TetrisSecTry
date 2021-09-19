using System;
using System.Collections.Generic;
using System.Text;

namespace TetrisSecTry
{
    class FigureL : Figure
    {
        public FigureL(int x, int y, char sym)
        {
            Points[0] = new Point(x, y, sym);
            Points[1] = new Point(x, y + 1, sym);
            Points[2] = new Point(x, y + 2, sym);
            Points[3] = new Point(x + 1, y + 2, sym);
            Draw();
        }

        public override void Rotate()
        {
            // The figure is in position L
            if (Points[0].X == Points[1].X && Points[0].X < Points[3].X)
            {
                RotateTo90Degrees();
            }
            // Figure L rotated 90 degrees 
            else if (Points[0].Y == Points[1].Y && Points[0].Y > Points[3].Y)
            {
                RotateTo180Degrees();
            }
            // Figure L rotated 180 degrees
            else if (Points[0].X == Points[1].X && Points[0].X > Points[3].X)
            {
                RotateTo270Degrees();
            }
            // Figure L rotated 270 degrees
            else if (Points[0].Y == Points[1].Y && Points[0].Y < Points[3].Y)
            {
                RotateTo360Degrees();
            }
        }

        private void RotateTo90Degrees()
        {
            for (int i = 0; i < Points.Length - 1; i++)
            {
                Points[i].Y = Points[0].Y;
                Points[i].X = Points[0].X + i;
            }
            Points[Points.Length - 1].X = Points[Points.Length - 1].X + 1;
            Points[Points.Length - 1].Y = Points[Points.Length - 1].Y - 3;
        }
        private void RotateTo180Degrees()
        {
            for (int i = 0; i < Points.Length - 1; i++)
            {
                Points[i].X = Points[0].X;
                Points[i].Y = Points[0].Y - i;
            }
            Points[Points.Length - 1].X = Points[Points.Length - 1].X - 3;
            Points[Points.Length - 1].Y = Points[Points.Length - 1].Y - 1;
        }
        private void RotateTo270Degrees()
        {
            for (int i = 0; i < Points.Length - 1; i++)
            {
                Points[i].Y = Points[0].Y;
                Points[i].X = Points[i].X - i;
            }
            Points[Points.Length - 1].X = Points[Points.Length - 1].X - 1;
            Points[Points.Length - 1].Y = Points[Points.Length - 1].Y + 3;
        }
        private void RotateTo360Degrees()
        {
            for (int i = 0; i < Points.Length - 1; i++)
            {
                Points[i].X = Points[0].X;
                Points[i].Y = Points[0].Y + i;
            }
            Points[Points.Length - 1].X = Points[Points.Length - 1].X + 3;
            Points[Points.Length - 1].Y = Points[Points.Length - 1].Y + 1;
        }
    }
}
