using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeiGratia.src.Tilemap
{
    internal class TileMapLayer
    {
        private int id;
        private string layerName;
        private int width;
        private int height;

        private int[] tiles;

        public int Id { get => id; set => id = value; }
        public string LayerName { get => layerName; set => layerName = value; }
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public int[] Tiles { get => tiles; set => tiles = value; }

        public TileMapLayer(int id, string layerName, int width, int height, int[] tiles)
        {
            Id = id;
            LayerName = layerName;
            Width = width;
            Height = height;
            Tiles = tiles;
        }

        public TileMapLayer(int id, string layerName)
        {
            Id = id;
            LayerName = layerName;
        }
    }
}
