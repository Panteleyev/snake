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

        public Snake( Point tail, int length, Direction _direction )
        {
            direction = _direction;
            pList = new List<Point>();
            for (int i = 0; i < length; i++)
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
            pList.Remove( tail );
            pList.Add( head );

            tail.Clear();
            head.Draw();
        }

        Point GetNextPoint()
        {
            // Point head = pList.Last();
            Point nextPoint = new Point( pList.Last() );
            nextPoint.Move( 1, direction );

            return nextPoint;
        }

        internal Point getPointHead()
        {
            return pList.Last();
        }

        internal bool IsHitTail()
        {
            var head = pList.Last();
            for (int i = 0; i < pList.Count - 2; i++)
            {
                if (head.IsHit( pList[ i ] ))
                    return true;
            }
            return false;
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

        internal bool Eat( Point food )
        {
            Point head = GetNextPoint();
            //Point head = pList.Last();// от комментатора

            //if (head.x == food.x && head.y == food.y)
            if (head.IsHit( food ))
            {
                food.sym = head.sym;

                //food.Draw();// перерисовка поглащенной еды
                //pList.Add( food );
                pList.Insert( 0, food );// съеденная еда появляется сразу, а не в хвосте
                return true;
            }
            else
                return false;
        }
    }
}
