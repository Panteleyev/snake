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

            Console.WriteLine( "Press [Enter] to start the game!" );
            Console.ReadLine();

            Console.SetBufferSize( frameWidth, frameHeight );
            Console.SetWindowSize( frameWidth, frameHeight );
            Console.CursorVisible = false;

            // Отрисовка рамочки
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
                if (walls.IsHit( snake.getPointHead() ) || snake.IsHitTail())
                {
                    break;
                }
                if (snake.Eat( food ))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }
                Thread.Sleep( 100 );

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey( true );
                    while (Console.KeyAvailable) key = Console.ReadKey( true ); // во избежании очереди за новым направлением
                    snake.HandleKey( key.Key );
                }
            }

            WriteGameOver( 25, 8 );
            Console.Read();
        }

        static void WriteGameOver( int xOffset, int yOffset )
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition( xOffset, yOffset++ );
            WriteText( "============================", xOffset, yOffset++ );
            WriteText( "G A M E   O V E R", xOffset + 5, yOffset++ );
            yOffset++;
            WriteText( "Author: Gleb Panteleyev", xOffset + 2, yOffset++ );
            WriteText( "Special for GeekBrains", xOffset + 2, yOffset++ );
            WriteText( "============================", xOffset, yOffset++ );
        }

        static void WriteText( string text, int xOffset, int yOffset )
        {
            Console.SetCursorPosition( xOffset, yOffset );
            Console.WriteLine( text );
        }
    }
}
