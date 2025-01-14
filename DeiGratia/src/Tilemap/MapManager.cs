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
    internal class MapManager
    {
        private TileMap map;
        private Grid grid;

        public MapManager(String filepath)
        {
            Map = new TmxLoader().LoadMap(filepath);
            Grid = new Grid(Map.Width, Map.Height, Map.TileWidth, Map.TileHeight);
        }

        internal TileMap Map { get => map; set => map = value; }
        internal Grid Grid { get => grid; set => grid = value; }

        public void LoadMap(String filepath)
        {
            Map = new TmxLoader().LoadMap(filepath);
        }



    }
}
