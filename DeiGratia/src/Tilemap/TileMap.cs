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

        public List<TileSet> TileSets { get; set;}

        public List<TileMapLayer> TileMapLayers { get; set;}

        public int Width { get; set;}
        public int Height { get; set;}
        public int TileWidth { get; set;}
        public int TileHeight { get; set;}
        public bool Infinite { get; set;}

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
