using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeiGratia.src.Tilemap
{
    internal class TileMapLayer
    {
        private int _id;
        private string _layerName;
        private int _width;
        private int _height;

        private int[] _tiles;

        public int Id { get => _id; set => _id = value; }
        public string LayerName { get => _layerName; set => _layerName = value; }
        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }
        public int[] Tiles { get => _tiles; set => _tiles = value; }

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
