using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using System;
using System.Diagnostics;
using DeiGratia.src.Tilemap;
using DeiGratia.src.Camera;

namespace DeiGratia.src
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Camera2D camera = new Camera2D();

        private TileMap tileMap;
        TileMapRenderer tileMapRenderer;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _graphics.PreferredBackBufferWidth = GraphicsDevice.Adapter.CurrentDisplayMode.Width / 2;
            _graphics.PreferredBackBufferHeight = GraphicsDevice.Adapter.CurrentDisplayMode.Height / 2;
            _graphics.ApplyChanges();


            TmxLoader _loader = new TmxLoader();
            tileMap = _loader.LoadMap(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + @"/maps/testmap.tmx");

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            tileMapRenderer = new TileMapRenderer(tileMap, _spriteBatch, this.Content);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            camera.Position = new Vector2(320f, 320f);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.get_transformation(_graphics.GraphicsDevice));
            tileMapRenderer.RenderMap();
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
