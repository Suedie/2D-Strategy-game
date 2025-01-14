using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeiGratia.src.Tilemap
{
    internal class TileMapRenderer
    {
        private TileMap _map;
        private SpriteBatch _spriteBatch;
        private ContentManager _content;
        private List<Texture2D> _tileTextures;
        private List<TileSet> _tileSets;
        private List<TileMapLayer> _layers;

        public TileMapRenderer(TileMap map, SpriteBatch spriteBatch, ContentManager content)
        {
            _spriteBatch = spriteBatch;
            _content = content;
            LoadMap(map);
        }


        public void RenderMap()
        {
            foreach (TileMapLayer layer in _layers)
            {
                int[] tiles = layer.Tiles;
                for (int i = 0; i < tiles.Length; i++)
                {
                    DrawTile(tiles[i], i, layer.Width);
                }
            }


        }

        private void LoadTextures()
        {
            _tileSets = _map.TileSets;
            _tileTextures = new List<Texture2D>();

            foreach (TileSet tileSet in _tileSets)
            {
                Texture2D texture = _content.Load<Texture2D>(tileSet.Name);
                _tileTextures.Add(texture);
            }

        }

        private void DrawTile(int id, int i, int width)
        {
            int drawY = i / width;
            int drawX = i % width;

            foreach (TileSet tileSet in _tileSets)
            {
                if (id >= tileSet.Firstgid && id <= tileSet.Firstgid + tileSet.TileCount)
                {
                    int srcY = (id - tileSet.Firstgid) / (tileSet.Width / tileSet.TileWidth) * tileSet.TileHeight;
                    int srcX = (id - tileSet.Firstgid) % (tileSet.Width / tileSet.TileWidth) * tileSet.TileWidth;

                    foreach (Texture2D texture in _tileTextures)
                    {
                        if (texture.Name == tileSet.Name)
                        {
                            _spriteBatch.Draw(texture, new Vector2(drawX * tileSet.TileWidth, drawY * tileSet.TileHeight), new Rectangle(srcX, srcY, tileSet.TileWidth, tileSet.TileHeight), Color.White);
                            break;
                        }
                    }
                }
            }
        }

        private void LoadMap(TileMap map)
        {
            this._map = map;
            _layers = map.TileMapLayers;
            if (_tileTextures != null)
            {
                foreach (Texture2D texture in _tileTextures)
                    texture.Dispose();
            }
            LoadTextures();
        }
    }
}
