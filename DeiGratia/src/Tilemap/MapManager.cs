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
        public TileMap Map { get; private set; }

        public MapManager(String filepath)
        {
            Map = new TmxLoader().LoadMap(filepath);
        }
        
        public void LoadMap(String filepath)
        {
            Map = new TmxLoader().LoadMap(filepath);
        }
    }
}
