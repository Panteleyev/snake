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

            int xStart = 10, xStep,
                yStart = 9, yStep,
                xTmp = xStart, yTmp = yStart;
            char sym = '+';

            xStep = 5;
            HorizontalLine hLine = new HorizontalLine( xTmp, xTmp = xTmp + xStep, yTmp, sym );
            hLine.Draw();

            yStep = 7;
            VerticalLine vLine = new VerticalLine( yTmp, yTmp = yTmp + yStep, xTmp, sym );
            vLine.Draw();

            xStep = -5;
            hLine = new HorizontalLine( xTmp, xTmp = xTmp + xStep, yTmp, sym );
            hLine.Draw();

            yStep = -5;
            vLine = new VerticalLine( yTmp, yTmp = yTmp + yStep, xTmp, sym );
            vLine.Draw();

            Console.ReadLine();
        }
    }
}
