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

        public int Id { get; set;}
        public string LayerName { get; set;}
        public int Width { get; set;}
        public int Height { get; set;}
        public int[] Tiles { get; set;}

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
