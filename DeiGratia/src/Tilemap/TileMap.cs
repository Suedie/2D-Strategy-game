using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeiGratia.src.Tilemap
{
    internal class TileMap
    {
        private List<TileSet> _tileSets;
        private List<TileMapLayer> _tileMapLayers;
        private int _width;
        private int _height;
        private int _tileWidth;
        private int _tileHeight;
        private bool _infinite;

        public List<TileSet> TileSets
        {
            get => _tileSets;
        }

        public List<TileMapLayer> TileMapLayers
        {
            get => _tileMapLayers;
        }

        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }
        public int TileWidth { get => _tileWidth; set => _tileWidth = value; }
        public int TileHeight { get => _tileHeight; set => _tileHeight = value; }
        public bool Infinite { get => _infinite; set => _infinite = value; }

        public TileMap(List<TileSet> tileSets, List<TileMapLayer> tileMapLayers, int width, int height, int tileWidth, int tileHeight, bool infinite)
        {
            _tileSets = tileSets;
            _tileMapLayers = tileMapLayers;
            Width = width;
            Height = height;
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            Infinite = infinite;
        }
    }
}
