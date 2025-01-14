using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Xml.Linq;

namespace DeiGratia.src.Tilemap
{
    
    // TODO: Maybe use factory pattern
    internal class MapManager
    {
        private TileMap _map;
        private Grid _grid;

        public MapManager(String filepath)
        {
            Map = new TmxLoader().LoadMap(filepath);
            Grid = new Grid(Map.Width, Map.Height, Map.TileWidth, Map.TileHeight);
        }

        internal TileMap Map { get => _map; set => _map = value; }
        internal Grid Grid { get => _grid; set => _grid = value; }

        public void LoadMap(String filepath)
        {
            Map = new TmxLoader().LoadMap(filepath);
        }



    }
}
