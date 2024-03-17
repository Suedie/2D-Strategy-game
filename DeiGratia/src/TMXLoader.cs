using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DeiGratia.src
{
    internal class TMXLoader
    {
        private XmlDocument tmxFile = new XmlDocument();
        private TileMap tilemap;
        private string filepath;

        public TMXLoader(string filepath)
        {
            this.filepath = filepath;
            LoadMap(filepath);
        }

        public void LoadMap(string filepath)
        {
            List<TileMapLayer> tileMapLayers = new List<TileMapLayer>();
            List<TileSet> tileSets = new List<TileSet>();

            tmxFile.Load(filepath);
            XmlNodeList layerNodes = tmxFile.GetElementsByTagName("layer");
            XmlNodeList tileSetNodes = tmxFile.GetElementsByTagName("tileset");

            foreach (XmlNode layerNode in layerNodes )
            {
                int id = -1;
                string layerName = "";
                int width = -1;
                int height = -1;

                XmlAttributeCollection layerAttributes = layerNode.Attributes;

                foreach (XmlAttribute layerAttr in layerAttributes )
                {
                    switch (layerAttr.Name)
                    {
                        case "id":
                            id = Int32.Parse(layerAttr.Value);
                            break;
                        case "name":
                            layerName = layerAttr.Value;
                            break;
                        case "width":
                            width = Int32.Parse(layerAttr.Value);
                            break;
                        case "height":
                            height = Int32.Parse(layerAttr.Value);
                            break;
                    }
                }

                string[] tileString = layerNode.FirstChild.InnerText.Split(",");
                int[] tiles = new int[tileString.Length];

                for (int i = 0; i < tileString.Length; i++) {

                    tiles[i] = Int32.Parse(tileString[i]);

                }

                TileMapLayer tileMapLayer = new TileMapLayer(id, layerName, width, height, tiles);
                tileMapLayers.Add(tileMapLayer);
            }
            
        }

    }
}