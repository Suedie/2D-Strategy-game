using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeiGratia.src.Tilemap
{
    internal class Grid
    {
        private int _width;
        private int _height;
        private int _tileWidth;
        private int _tileHeight;

        public Grid(int width, int height, int tileWidth, int tileHeight)
        {
            this._width = width;
            this._height = height;
            this._tileWidth = tileWidth;
            this._tileHeight = tileHeight;
        }

        public int SetX(int x)
        {
            return x + _tileWidth;
        }

        public int SetY(int y)
        {
            return y + _tileHeight;
        }
    }
}
