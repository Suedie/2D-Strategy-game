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
        private TileMap tileMap;
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

                foreach (XmlAttribute layerAttribute in layerAttributes )
                {
                    switch (layerAttribute.Name)
                    {
                        case "id":
                            id = Int32.Parse(layerAttribute.Value);
                            break;
                        case "name":
                            layerName = layerAttribute.Value;
                            break;
                        case "width":
                            width = Int32.Parse(layerAttribute.Value);
                            break;
                        case "height":
                            height = Int32.Parse(layerAttribute.Value);
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

            foreach (XmlNode tileSetNode  in tileSetNodes)
            {
                int firstgid = -1;
                string name = "";
                int tileWidth = 0;
                int tileHeight = 0;
                int tileCount = 0;
                int columns = 0;

                string source = "";
                int height = 0;
                int width = 0;

                XmlAttributeCollection tileSetAttributes = tileSetNode.Attributes;

                foreach (XmlNode tileSetAttribute in tileSetAttributes)
                {
                    switch (tileSetAttribute.Name)
                    {
                        case "firstgid":
                            firstgid = Int32.Parse(tileSetAttribute.Value);
                            break;
                        case "name":
                            name = tileSetAttribute.Value;
                            break;
                        case "tilewidth":
                            tileWidth = Int32.Parse(tileSetAttribute.Value);
                            break;
                        case "tileheight":
                            tileHeight = Int32.Parse(tileSetAttribute.Value);
                            break;
                        case "tilecount":
                            tileCount = Int32.Parse(tileSetAttribute.Value);
                            break;
                        case "columns":
                            columns = Int32.Parse(tileSetAttribute.Value);
                            break;
                    }
                }

                XmlAttributeCollection tileSetDataAttributes = tileSetNode.FirstChild.Attributes;

                foreach (XmlNode tileSetData in tileSetDataAttributes)
                {
                    switch (tileSetData.Name)
                    {
                        case "source":
                            source = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + tileSetData.Value;
                            break;
                        case "height":
                            height = Int32.Parse(tileSetData.Value);
                            break;
                        case "width":
                            width = Int32.Parse(tileSetData.Value);
                            break;
                    }
                }

                TileSet tileSet = new TileSet(firstgid, name, tileWidth, tileHeight, tileCount, columns, source, width, height);
                tileSets.Add(tileSet);

            }

            //Fix it so it fetches infinite from the tilemap file
            tileMap = new TileMap(tileSets, tileMapLayers, 0);
        }
    }
}