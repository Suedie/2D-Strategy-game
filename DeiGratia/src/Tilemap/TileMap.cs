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



        public TileMap(List<TileSet> tileSets, List<TileMapLayer> tileMapLayers, int width, int height, int tileWidth, int tileHeight, bool infinite)
        {
            this.tileSets = tileSets;
            this.tileMapLayers = tileMapLayers;
            this.width = width;
            this.height = height;
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            this.infinite = infinite;
        }
    }
}
