using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace DeiGratia.src.Tilemap
{
    internal class TmxLoader
    {
        private XmlDocument _tmxFile = new XmlDocument();

        public TmxLoader()
        {

        }

        public XmlDocument TmxFile { get; set;}

        //Converts a .tmx map into a C# object
        public TileMap LoadMap(string filepath)
        {
            _tmxFile.Load(filepath);
            XmlNodeList layerNodes = _tmxFile.GetElementsByTagName("layer");
            XmlNodeList tileSetNodes = _tmxFile.GetElementsByTagName("tileset");
            XmlAttributeCollection mapAttributes = _tmxFile.GetElementsByTagName("map").Item(0).Attributes;

            //Initialised with invalid-default values
            int width = -1;
            int height = -1;
            int tileWidth = -1;
            int tileHeight = -1;
            bool isInfinite = false;

            //Loads attributes from tilemap
            foreach (XmlAttribute mapAttribute in mapAttributes)
            {
                if (mapAttribute.Name == "width")
                {
                    width = int.Parse(mapAttribute.Value);
                } else if (mapAttribute.Name == "height")
                {
                    height = int.Parse(mapAttribute.Value);
                } else if (mapAttribute.Name == "tileWidth")
                {
                    tileWidth = int.Parse(mapAttribute.Value);
                } else if (mapAttribute.Name == "tileHeight")
                {
                    tileHeight = int.Parse(mapAttribute.Value);
                } else if (mapAttribute.Name == "infinite")
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

            return new TileMap(tileSets, tileMapLayers, width, height, tileWidth, tileHeight, isInfinite);
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

                //Each layer only has one child, <data> which contains the id of each tile
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