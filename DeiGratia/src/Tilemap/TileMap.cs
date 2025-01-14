using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeiGratia.src.Tilemap
{
    internal class TileMap
    {
        private List<TileSet> tileSets;
        private List<TileMapLayer> tileMapLayers;
        private int width;
        private int height;
        private int tileWidth;
        private int tileHeight;
        private bool infinite;

        public List<TileSet> TileSets
        {
            get { return tileSets; }
        }

        public List<TileMapLayer> TileMapLayers
        {
            get { return tileMapLayers; }
        }

        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public int TileWidth { get => tileWidth; set => tileWidth = value; }
        public int TileHeight { get => tileHeight; set => tileHeight = value; }
        public bool Infinite { get => infinite; set => infinite = value; }

        public TileMap(List<TileSet> tileSets, List<TileMapLayer> tileMapLayers, int width, int height, int tileWidth, int tileHeight, bool infinite)
        {
            this.tileSets = tileSets;
            this.tileMapLayers = tileMapLayers;
            this.Width = width;
            this.Height = height;
            this.TileWidth = tileWidth;
            this.TileHeight = tileHeight;
            this.Infinite = infinite;
        }
    }
}
