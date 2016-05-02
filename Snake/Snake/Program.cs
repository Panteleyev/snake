using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main( string[] args )
        {
            int x = 1;
            Func1( x );
            Console.WriteLine( "Call Func1. x = " + x );

            Func2( x );
            Console.WriteLine( "Call Func2. x = " + x );

            Func3( x );
            Console.WriteLine( "Call Func3. x = " + x );

            Point p1 = new Point( 1, 3, '*' );
            Move( p1, 10, 10 );
            Console.WriteLine( "Call Move. p1.x = " + p1.x + ", p1.y = " + p1.y );
            p1.Draw();

            Point p2 = new Point( 4, 6, '#' );
            p2.Draw();

            p1 = p2;
            p1.x = 8;
            p2.y = 8;
            Console.WriteLine( "p1 = p2. p1.x = " + p1.x + ", p1.y = " + p1.y + "; p2.x = " + p2.x + ", p2.y = " + p2.y );

            p1 = new Point( 1, 3, '*' );
            Reset( p1 );
            Console.WriteLine( "Call Reset. p1.x = " + p1.x + ", p1.y = " + p1.y );

            Console.ReadLine();
        }

        public static void Func1( int value )
        {
        }

        public static void Func2( int value )
        {
            value = value + 1;
        }

        public static void Func3( int x )
        {
            x = x + 1;
        }

        public static void Move( Point p, int dx, int dy )
        {
            Console.WriteLine( "Before call constructor in Move. p.x = " + p.x + ", p.y = " + p.y );
            p.x = p.x + dx;
            p.y = p.y + dy;
            Console.WriteLine( "After call constructor in Move. p.x = " + p.x + ", p.y = " + p.y );
        }

        public static void Reset( Point p )
        {
            Console.WriteLine( "Before call constructor in Reset. p.x = " + p.x + ", p.y = " + p.y );
            p = new Point();
            Console.WriteLine( "After call constructor in Reset. p.x = " + p.x + ", p.y = " + p.y );
        }
    }
}
