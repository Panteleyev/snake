using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake : Figure
    {
        Direction direction;

        public Snake( Point tail, int lenght, Direction _direction )
        {
            direction = _direction;
            pList = new List<Point>();
            for (int i = 0; i < lenght; i++)
            {
                Point p = new Point( tail );
                p.Move( i, direction );
                pList.Add( p );
            }
        }

        internal void Move()
        {
            Point tail = pList.First();
            //pList.Remove( tail );
            Point head = GetNextPoint();
            if (head.x < 78 && head.x > 0 && head.y < 24 && head.y > 0)
            {
                pList.Remove( tail );
                pList.Add( head );

                tail.Clear();
                head.Draw();
            }

        }

        private Point GetNextPoint()
        {
            // Point head = pList.Last();
            Point nextPoint = new Point( pList.Last() );
            nextPoint.Move( 1, direction );

            return nextPoint;
        }

        internal void HandleKey( ConsoleKey key )
        {
            if (key == ConsoleKey.LeftArrow && direction != Direction.RIGHT)
                direction = Direction.LEFT;
            else if (key == ConsoleKey.RightArrow && direction != Direction.LEFT)
                direction = Direction.RIGHT;
            else if (key == ConsoleKey.UpArrow && direction != Direction.DOWN)
                direction = Direction.UP;
            else if (key == ConsoleKey.DownArrow && direction != Direction.UP)
                direction = Direction.DOWN;
        }
    }
}
