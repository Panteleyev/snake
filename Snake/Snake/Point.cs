using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Point
    {
        public int x;
        public int y;
        public char sym;

        public Point()
        {
        }

        public Point( int _x, int _y, char _sym )
        {
            this.x = _x;
            this.y = _y;
            this.sym = _sym;
        }

        public Point( Point p ) : this( p.x, p.y, p.sym )
        {
        }

        public void Move( int offset, Direction direction )
        {
            switch (direction)
            {
                case Direction.RIGHT:
                    x += offset;
                    break;
                case Direction.LEFT:
                    x -= offset;
                    break;
                case Direction.UP:
                    y -= offset;
                    break;
                case Direction.DOWN:
                    y += offset;
                    break;
            }
        }

        public void Draw()
        {
            Console.SetCursorPosition( x, y );
            Console.Write( sym );
        }

        internal void Clear()
        {
            sym = ' ';
            Draw();
        }

        public override string ToString()
        {
            return x + ", " + y + ", " + sym;
        }

        internal bool IsHit( Point p )
        {
            //return p.x == x && p.y == y;
            return p.x == this.x && p.y == this.y;
        }
    }
}
