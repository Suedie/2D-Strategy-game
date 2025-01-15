using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DeiGratia.src.Entities;

public class EntityRenderer
{
    private IEntity _player;
    private Texture2D _texture;
    private SpriteBatch _spriteBatch;
    private ContentManager _content;
    
    public EntityRenderer(IEntity player, SpriteBatch spriteBatch, ContentManager content)
    {
        this._player = player;
        this._spriteBatch = spriteBatch;
        this._content = content;
    }

    public EntityRenderer(SpriteBatch spriteBatch, ContentManager content)
    {
        _spriteBatch = spriteBatch;
        _content = content;
    }

    public void DrawPlayer()
    {
        _texture = _content.Load<Texture2D>("IDLE");
        _spriteBatch.Draw(_texture, _player.Position,
            new Rectangle(32, 28, 32, 32), Color.White, 0f, Vector2.Zero,
            1f, SpriteEffects.None, 0.3f);
    }
    
}