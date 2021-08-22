using System;
using System.Collections.Generic;
using System.Text;

namespace TetrisSecTry
{
    class Stick : Figure
    {
        

        public Stick (int x, int y, char sym)
        {
            points[0] = new Point(x, y, sym);
            points[1] = new Point(x, y + 1, sym);
            points[2] = new Point(x, y + 2, sym);
            points[3] = new Point(x, y + 3, sym);
            Draw();

        }

        public override void Rotate()
        {
            if (points[0].x == points[1].x)
            {
                RotateHorizontical();
            } else
            {
                RotataVertcal();
            }
        }
        private void RotateHorizontical()
        {
            for (int i = 0; i < points.Length; i++)
            {
                points[i].y = points[0].y;
                points[i].x = points[0].x + i;
            }
        }

        private void RotataVertcal()
        {
            for (int i = 0; i < points.Length; i++)
            {
                points[i].x = points[0].x;
                points[i].y = points[0].y + i;
            }
        }


    }
}
