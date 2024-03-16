using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeiGratia.src
{
    internal class TileSet
    {

        private int firstgid;
        private string name;
        private int tileWidth;
        private int tileHeight;
        private int tileCount;
        private int columns;
        private string source;
        private int width;
        private int height;

        public TileSet(int firstgid, string name, int tileWidth, int tileHeight, int tileCount, int columns, string source, int width, int height)
        {
            this.firstgid = firstgid;
            this.name = name;
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            this.tileCount = tileCount;
            this.columns = columns;
            this.source = source;
            this.width = width;
            this.height = height;
        }
    }
}
