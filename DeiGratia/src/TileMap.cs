using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeiGratia.src
{
    internal class TileMap
    {
        private List<TileSet> tileSets {  get; set; }
        private List<TileMapLayer> tileMapLayers { get; set; }
        private bool infinite;

        public TileMap(List<TileSet> tileSets, List<TileMapLayer> tileMapLayers, bool infinite)
        {
            this.tileSets = tileSets;
            this.tileMapLayers = tileMapLayers;
            this.infinite = infinite;
        }
    }
}
