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

        public int Firstgid { get; set;}
        public string Name { get; set;}
        public int TileWidth { get; set;}
        public int TileHeight { get; set;}
        public int TileCount { get; set;}
        public int Columns { get; set;}
        public string Source { get; set;}
        public int Width { get; set;}
        public int Height { get; set;}
    }
}
