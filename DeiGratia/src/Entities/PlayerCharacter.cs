using Microsoft.Xna.Framework;

namespace DeiGratia.src.Entities;

public class PlayerCharacter : IEntity
{

    private Vector2 _position;
    private int _healthPoints;
    private int _movementPoints;
    
    public int MovementPoints => _movementPoints;

    public Vector2 Position { get => _position; set => _position = value; }

    public PlayerCharacter(int x, int y)
    {
        Position = new Vector2(x, y);
    }
    
    public void Move(Vector2 amount)
    {
        _position += amount;
    }
    
    
    
    
}