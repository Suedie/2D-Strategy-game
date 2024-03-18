using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeiGratia.src
{
    internal class TileMapRenderer
    {
        private TileMap map;
        private SpriteBatch spriteBatch;
        ContentManager content;
        List<Texture2D> tileTextures;
        List<TileSet> tileSets;
        List<TileMapLayer> layers;

        public TileMapRenderer(TileMap map, SpriteBatch spriteBatch, ContentManager content)
        {
            this.map = map;
            this.spriteBatch = spriteBatch;
            this.content = content;
        }


        public void RenderMap()
        {
            layers = map.TileMapLayers;
            LoadTextures();
            spriteBatch.Begin();
            foreach (TileMapLayer layer in layers)
            {
                int[] tiles = layer.Tiles;
                for (int i = 0; i < tiles.Length; i++)
                {
                    DrawTile(tiles[i], i, layer.Width);
                }
            }
            spriteBatch.End();


        }

        private void LoadTextures()
        {
            tileSets = map.TileSets;
            tileTextures = new List<Texture2D> ();

            foreach (TileSet tileSet in tileSets)
            {
                Texture2D texture = this.content.Load<Texture2D>(tileSet.Name);
                tileTextures.Add(texture);
            }

        }

        private void DrawTile(int id, int i, int width)
        {
            int drawY = i / width;
            int drawX = i % width;

            foreach (TileSet tileSet in tileSets)
            {
                if (id >= tileSet.Firstgid && id <= (tileSet.Firstgid + tileSet.TileCount))
                {
                    int srcY = ((id - tileSet.Firstgid) / (tileSet.Width / tileSet.TileWidth))* tileSet.TileHeight;
                    int srcX = ((id - tileSet.Firstgid) % (tileSet.Width / tileSet.TileWidth)) * tileSet.TileWidth;

                    foreach (Texture2D texture in tileTextures)
                    {
                        if (texture.Name == tileSet.Name)
                        {
                            spriteBatch.Draw(texture, new Vector2(drawX * tileSet.TileWidth, drawY * tileSet.TileHeight), new Rectangle(srcX, srcY, tileSet.TileWidth, tileSet.TileHeight), Color.White);
                        }
                    }
                }
            }
        }
    }
}
