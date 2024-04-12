using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DeiGratia.src.Tilemap
{
    internal class TmxLoader
    {
        private XmlDocument tmxFile = new XmlDocument();

        public TmxLoader()
        {

        }

        public XmlDocument TmxFile { get => tmxFile; set => tmxFile = value; }

        //Converts a .tmx map into a C# object
        public TileMap LoadMap(string filepath)
        {
            TmxFile.Load(filepath);
            XmlNodeList layerNodes = TmxFile.GetElementsByTagName("layer");
            XmlNodeList tileSetNodes = TmxFile.GetElementsByTagName("tileset");
            XmlAttributeCollection mapAttributes = TmxFile.GetElementsByTagName("map").Item(0).Attributes;

            bool isInfinite = false;

            foreach (XmlAttribute mapAttribute in mapAttributes)
            {
                if (mapAttribute.Name == "infinite")
                {
                    int infiniteValue = int.Parse(mapAttribute.Value);
                    if (infiniteValue == 1)
                        isInfinite = true;
                    else
                        isInfinite = false;
                }
            }

            List<TileMapLayer> tileMapLayers = TileMapLayerLoader(layerNodes);
            List<TileSet> tileSets = TileSetLoader(tileSetNodes);

            return new TileMap(tileSets, tileMapLayers, isInfinite);
        }

        //Helper function that loads every layer in a tilemap and returns them in a list.
        private List<TileMapLayer> TileMapLayerLoader(XmlNodeList layerNodes)
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
                            id = int.Parse(layerAttribute.Value);
                            break;
                        case "name":
                            layerName = layerAttribute.Value;
                            break;
                        case "width":
                            width = int.Parse(layerAttribute.Value);
                            break;
                        case "height":
                            height = int.Parse(layerAttribute.Value);
                            break;
                    }
                }

                string[] tileString = layerNode.FirstChild.InnerText.Split(",");
                int[] tiles = new int[tileString.Length];

                for (int i = 0; i < tileString.Length; i++)
                {

                    tiles[i] = int.Parse(tileString[i]);

                }

                TileMapLayer tileMapLayer = new TileMapLayer(id, layerName, width, height, tiles);
                tileMapLayers.Add(tileMapLayer);
            }

            return tileMapLayers;

        }

        //Helper function that loads every tileset from a tilemap and returns them in a list.
        private List<TileSet> TileSetLoader(XmlNodeList tileSetNodes)
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
                            firstgid = int.Parse(tileSetAttribute.Value);
                            break;
                        case "name":
                            name = tileSetAttribute.Value;
                            break;
                        case "tilewidth":
                            tileWidth = int.Parse(tileSetAttribute.Value);
                            break;
                        case "tileheight":
                            tileHeight = int.Parse(tileSetAttribute.Value);
                            break;
                        case "tilecount":
                            tileCount = int.Parse(tileSetAttribute.Value);
                            break;
                        case "columns":
                            columns = int.Parse(tileSetAttribute.Value);
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
                            height = int.Parse(tileSetData.Value);
                            break;
                        case "width":
                            width = int.Parse(tileSetData.Value);
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