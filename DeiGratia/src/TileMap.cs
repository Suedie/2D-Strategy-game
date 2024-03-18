using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeiGratia.src
{
    internal class TileMap
    {
        private List<TileSet> tileSets;
        private List<TileMapLayer> tileMapLayers;
        private bool infinite;

        public List<TileSet> TileSets
        {
            get { return tileSets; }
        }

        public List<TileMapLayer> TileMapLayers
        {
            get { return tileMapLayers; }
        }



        public TileMap(List<TileSet> tileSets, List<TileMapLayer> tileMapLayers, bool infinite)
        {
            this.tileSets = tileSets;
            this.tileMapLayers = tileMapLayers;
            this.infinite = infinite;
        }
    }
}
