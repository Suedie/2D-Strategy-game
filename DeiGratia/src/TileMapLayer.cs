using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeiGratia.src
{
    internal class TileMapLayer
    {
        private int id;
        private string layerName;
        private int width;
        private int height;

        private int[] tiles;

        public TileMapLayer(int id, string layerName, int width, int height, int[] tiles)
        {
            this.id = id;
            this.layerName = layerName;
            this.width = width;
            this.height = height;
            this.tiles = tiles;
        }

        public TileMapLayer(int id, string layerName)
        {
            this.id = id;
            this.layerName = layerName;
        }
    }
}
