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
            int frameWidth = 80,
                frameHeight = 25;

            Console.WriteLine( "Нажмите enter, чтобы начать" );
            Console.ReadLine();

            // Отрисовка рамочки
            Console.SetBufferSize( frameWidth, frameHeight );
            Console.SetWindowSize( frameWidth, frameHeight );
            Console.CursorVisible = false;

            Walls walls = new Walls( frameWidth, frameHeight );
            walls.Draw();

            // Отрисовка точек
            Point p = new Point( 4, 5, '*' );
            //p.Draw();
            Snake snake = new Snake( p, 4, Direction.RIGHT );
            snake.Draw();

            // Создаем еду
            FoodCreator foodCreator = new FoodCreator( frameWidth, frameHeight, '$' );
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if (walls.IsHit( snake ) || snake.IsHitTail())
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine( "GAME OVER!" );
                    Console.ReadLine();
                    break;
                }
                if (snake.Eat( food ))
                {
                    food = foodCreator.CreateFood();
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
        }
    }
}
