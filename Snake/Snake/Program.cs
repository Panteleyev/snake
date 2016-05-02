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
            Point p1 = new Point( 1, 3, '*' );
            p1.Draw();

            Point p2 = new Point( 4, 5, '#' );
            p2.Draw();

            Point p3 = new Point( 2, 5, '@' );
            p3.Draw();

            List<int> numList = new List<int>();
            numList.Add( 0 );
            numList.Add( 4 );
            numList.Add( 5 );
            numList.Add( 6 );

            int x = numList[ 0 ];
            int y = numList[ 1 ];
            int z = numList[ 2 ];

            foreach (int i in numList)
            {
                Console.WriteLine( i );
            }

            numList.RemoveAt( 1 );

            List<Point> pList = new List<Point>();
            pList.Add( p1 );
            pList.Add( p2 );
            pList.Add( p3 );
            pList.Add( new Point( 6, 10, '+' ) );
            pList.Last().Draw();

            foreach (Point i in pList)
            {
                Console.WriteLine( "[" + i.x + ":" + i.y + "]: " + i.sym );
            }

            Console.ReadLine();
        }
    }
}
