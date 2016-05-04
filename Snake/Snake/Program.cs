using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main( string[] args )
        {
            VerticalLine v1 = new VerticalLine( 0, 10, 5, '%' );
            Draw( v1 );

            // Отрисовка точек
            Point p = new Point( 4, 5, '*' );
            //p.Draw();

            //Snake snake = new Snake( p, 4, Direction.RIGHT );
            Figure fSnake = new Snake( p, 4, Direction.RIGHT );
            Draw( fSnake );
            Snake snake = (Snake)fSnake; // Приведение типа явно
            //snake.Move...

            HorizontalLine h1 = new HorizontalLine( 0, 5, 6, '&' );

            List<Figure> figures = new List<Figure>();
            figures.Add( fSnake );
            figures.Add( v1 );
            figures.Add( h1 );

            foreach (var f in figures)
            {
                f.Draw();
            }

            //Console.ReadLine();// Ctrl + F5
        }

        static void Draw( Figure figure )
        {
            figure.Draw();
        }
    }
}
