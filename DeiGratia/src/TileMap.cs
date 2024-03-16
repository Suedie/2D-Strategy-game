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

        public TileMap(List<TileSet> tileSets, List<TileMapLayer> tileMapLayers)
        {
            this.tileSets = tileSets;
            this.tileMapLayers = tileMapLayers;
        }
    }
}
