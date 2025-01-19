using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DeiGratia.src.Entities;

public class EntityRenderer
{
    private IEntity _entity;
    private Texture2D _texture;
    private SpriteBatch _spriteBatch;
    private ContentManager _content;
    private String _name;
    
    private float _frametime = 200f;
    private float _timer;
    private int _currentFrame = 0;
    private int _totalFrames = 8;
    
    public EntityRenderer(IEntity entity, SpriteBatch spriteBatch, ContentManager content)
    {
        this._entity = entity;
        this._spriteBatch = spriteBatch;
        this._content = content;
        this._name = entity.Name;
    }

    public EntityRenderer(SpriteBatch spriteBatch, ContentManager content)
    {
        _spriteBatch = spriteBatch;
        _content = content;
    }

    public void DrawEntity(GameTime gameTime)
    {
        _texture = _content.Load<Texture2D>("Mini"+ _name + "Man");
        _timer += gameTime.ElapsedGameTime.Milliseconds;

        if (_timer >= _frametime)
        {
            _timer -= _frametime;
            _currentFrame = (_currentFrame + 1) % _totalFrames;
        }
        
        _spriteBatch.Draw(_texture, _entity.Position,
            new Rectangle(_currentFrame * 32, 0, 32, 32), Color.White, 0f, Vector2.Zero, 
            1f, SpriteEffects.None, 0.3f);
    }
    
}