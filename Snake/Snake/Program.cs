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
            int xStart = 0,
                frameWidth = Console.BufferWidth,
                yStart = 0,
                frameHeight = 70,//Console.BufferHeight,
                xTmp = xStart,
                yTmp = yStart;
            char sym = '+';

            // Отрисовка рамочки
            Console.SetWindowSize( frameWidth, frameHeight );

            HorizontalLine hLine = new HorizontalLine( xTmp, xTmp += frameWidth - 1, yTmp, sym );
            hLine.Draw();

            VerticalLine vLine = new VerticalLine( yTmp, yTmp += frameHeight - 1, xTmp, sym );
            vLine.Draw();

            hLine = new HorizontalLine( xTmp, xTmp -= frameWidth - 1, yTmp, sym );
            hLine.Draw();

            vLine = new VerticalLine( yTmp, yTmp -= frameHeight - 1, xTmp, sym );
            vLine.Draw();

            // Отрисовка точек
            Point p = new Point( 4, 5, '*' );
            p.Draw();

            Console.SetBufferSize( frameWidth, frameHeight );
            Console.ReadLine();
        }
    }
}
