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
            int frameWidth = 10,
                frameHeight = 10;

            // Отрисовка рамочки
            //            Console.SetBufferSize( frameWidth, frameHeight );
            //Console.SetWindowSize( frameWidth, frameHeight );
            Console.CursorVisible = false;

            HorizontalLine upLine = new HorizontalLine( 0, frameWidth - 2, 0, '+' );
            HorizontalLine downLine = new HorizontalLine( 0, frameWidth - 2, frameHeight - 1, '+' );
            VerticalLine leftLine = new VerticalLine( 0, frameHeight - 1, 0, '+' );
            VerticalLine rightLine = new VerticalLine( 0, frameHeight - 1, frameWidth - 2, '+' );
            upLine.Draw();
            downLine.Draw();
            leftLine.Draw();
            rightLine.Draw();

            // Отрисовка точек
            Point p = new Point( 4, 5, '*' );
            //p.Draw();
            Snake snake = new Snake( p, 4, Direction.RIGHT );
            snake.Draw();

            // Создаем еду
            FoodCreator foodCreator = new FoodCreator( frameWidth, frameHeight, '$' );
            Point food = foodCreator.CreateFood( snake.getPlist() );
            food.Draw();

            while (true)
            {
                if (snake.eat( food ))
                {
                    //food.Draw();// из-за бага с отображениеме новой еды
                    food = foodCreator.CreateFood( snake.getPlist() );
                    food.Draw();
                }
                else
                {
                    snake.Move( frameWidth, frameHeight );
                }
                Thread.Sleep( 100 );

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey( true );
                    while (Console.KeyAvailable) key = Console.ReadKey( true ); // во избежании очереди за новым направлением
                    snake.HandleKey( key.Key );
                }
            }

            //Console.ReadLine();// Ctrl + F5
        }
    }
}
