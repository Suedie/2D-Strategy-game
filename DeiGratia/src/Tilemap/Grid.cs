using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeiGratia.src.Tilemap
{
    internal class Grid
    {
        private int width;
        private int height;
        private int tileWidth;
        private int tileHeight;

        public Grid(int width, int height, int tileWidth, int tileHeight)
        {
            this.width = width;
            this.height = height;
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
        }

        public int setX(int x)
        {
            return x + tileWidth;
        }

        public int setY(int y)
        {
            return y + tileHeight;
        }
    }
}
