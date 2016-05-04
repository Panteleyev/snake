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

        internal void Move( int frameWidth, int frameHeight )
        {
            Point tail = pList.First();
            //pList.Remove( tail );
            Point head = GetNextPoint();
            if (head.x < frameWidth - 2 && head.x > 0 && head.y < frameHeight - 1 && head.y > 0)
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

        internal List<Point> getPlist()
        {
            return pList;
        }

        internal bool eat( Point food )
        {
            Point head = GetNextPoint();
            //Point head = pList.Last();// от комментатора
            
            //if (head.x == food.x && head.y == food.y)
            if (head.IsHit( food ))
            {
                food.sym = head.sym;
                //food.Draw();// перерисовка поглащенной еды

                pList.Insert( 0, food );// съеденная еда появляется сразу, а не в хвосте
                //pList.Add( food );
                return true;
            }
            else
                return false;
        }
    }
}
