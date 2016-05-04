using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class FoodCreator
    {
        private int mapWidth;
        private int mapHeight;
        private char sym;

        Random random = new Random();

        internal FoodCreator( int mapWidth, int mapHeight, char sym )
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.sym = sym;
        }

        internal Point CreateFood( List<Point> snakePList )
        {
            int x, y;
            Point p;

            //Создание данных о новой еде с учетом данных о змейке
            do
            {
                x = random.Next( 2, mapWidth - 2 );
                y = random.Next( 2, mapHeight - 2 );
                p = new Point( x, y, sym );
            } while (snakePList.Contains( p ));

            return p;

            //int x = random.Next( 2, mapWidth - 2 );
            //int y = random.Next( 2, mapHeight - 2 );
            //return new Point( x, y, sym );
        }
    }
}
