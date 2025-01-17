using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using DeiGratia.src.Tilemap;
using DeiGratia.src.Camera;
using DeiGratia.src.Entities;

namespace DeiGratia.src
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Camera2D _camera = new Camera2D();
        private EntityRenderer _entityRenderer;
        private MapManager _mapManager;
        private TileMapRenderer _tileMapRenderer;
        private IEntity _player = new PlayerCharacter(320, 320);
        
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

            _mapManager = new MapManager(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + @"/maps/testmap.tmx");

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _tileMapRenderer = new TileMapRenderer(_mapManager.Map, _spriteBatch, this.Content);
            _entityRenderer = new EntityRenderer(_player, _spriteBatch, this.Content);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                _player.Move(new Vector2(-32 * (float)gameTime.ElapsedGameTime.TotalSeconds, 0));

            // TODO: Add your update logic here

            _camera.Position = new Vector2(320f, 320f);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend,
                null, null, null, null,
                _camera.get_transformation(_graphics.GraphicsDevice));
            
            _tileMapRenderer.RenderMap();
            _entityRenderer.DrawPlayer();
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
