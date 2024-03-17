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
    internal class TmxLoader
    {
        private XmlDocument tmxFile = new XmlDocument();
        private TileMap tileMap;
        private string filepath;

        public TmxLoader()
        {

        }
        public TmxLoader(string filepath)
        {
            this.filepath = filepath;
            LoadMap(filepath);
        }

        //Converts a .tmx map into a C# object
        public void LoadMap(string filepath)
        {
            tmxFile.Load(filepath);
            XmlNodeList layerNodes = tmxFile.GetElementsByTagName("layer");
            XmlNodeList tileSetNodes = tmxFile.GetElementsByTagName("tileset");

            List<TileMapLayer> tileMapLayers = tileMapLayerLoader(layerNodes);
            List<TileSet> tileSets = tileSetLoader(tileSetNodes);

            //Fix it so it fetches infinite from the tilemap file
            tileMap = new TileMap(tileSets, tileMapLayers, 0);
        }

        //Helper function that loads every layer in a tilemap and returns them in a list.
        private List<TileMapLayer> tileMapLayerLoader(XmlNodeList layerNodes)
        {
            List<TileMapLayer> tileMapLayers = new List<TileMapLayer>();

            foreach (XmlNode layerNode in layerNodes)
            {
                int id = -1;
                string layerName = "";
                int width = -1;
                int height = -1;

                XmlAttributeCollection layerAttributes = layerNode.Attributes;

                foreach (XmlAttribute layerAttribute in layerAttributes)
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

                for (int i = 0; i < tileString.Length; i++)
                {

                    tiles[i] = Int32.Parse(tileString[i]);

                }

                TileMapLayer tileMapLayer = new TileMapLayer(id, layerName, width, height, tiles);
                tileMapLayers.Add(tileMapLayer);
            }

            return tileMapLayers;

        }

        //Helper function that loads every tileset from a tilemap and returns them in a list.
        private List<TileSet> tileSetLoader(XmlNodeList tileSetNodes)
        {
            List<TileSet> tileSets = new List<TileSet>();

            foreach (XmlNode tileSetNode in tileSetNodes)
            {
                int firstgid = -1;
                string name = "";
                int tileWidth = -1;
                int tileHeight = -1;
                int tileCount = -1;
                int columns = -1;

                string source = "";
                int height = -1;
                int width = -1;

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

            return tileSets;

        }

    }
}