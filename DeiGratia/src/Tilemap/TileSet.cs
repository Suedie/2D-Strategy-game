using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeiGratia.src.Tilemap
{
    internal class TileSet
    {

        private int _firstgid;
        private string _name;
        private int _tileWidth;
        private int _tileHeight;
        private int _tileCount;
        private int _columns;
        private string _source;
        private int _width;
        private int _height;

        public TileSet(int firstgid, string name, int tileWidth, int tileHeight, int tileCount, int columns, string source, int width, int height)
        {
            _firstgid = firstgid;
            _name = name;
            _tileWidth = tileWidth;
            _tileHeight = tileHeight;
            _tileCount = tileCount;
            _columns = columns;
            _source = source;
            _width = width;
            _height = height;
        }

        public int Firstgid { get => _firstgid; set => _firstgid = value; }
        public string Name { get => _name; set => _name = value; }
        public int TileWidth { get => _tileWidth; set => _tileWidth = value; }
        public int TileHeight { get => _tileHeight; set => _tileHeight = value; }
        public int TileCount { get => _tileCount; set => _tileCount = value; }
        public int Columns { get => _columns; set => _columns = value; }
        public string Source { get => _source; set => _source = value; }
        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }
    }
}
