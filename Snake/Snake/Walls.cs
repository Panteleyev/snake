﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Walls
    {
        List<Figure> wallList;

        public Walls( int mapWidth, int mapHeight )
        {
            wallList = new List<Figure>();

            wallList.Add( new HorizontalLine( 0, mapWidth - 2, 0, '+' ) );
            wallList.Add( new HorizontalLine( 0, mapWidth - 2, mapHeight - 1, '+' ) );
            wallList.Add( new VerticalLine( 0, mapHeight - 1, 0, '+' ) );
            wallList.Add( new VerticalLine( 0, mapHeight - 1, mapWidth - 2, '+' ) );
        }

        public void Draw()
        {
            foreach (var wall in wallList)
            {
                wall.Draw();
            }
        }

        internal bool IsHit( Point point )
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit( point ))
                    return true;
            }
            return false;
        }
    }
}
