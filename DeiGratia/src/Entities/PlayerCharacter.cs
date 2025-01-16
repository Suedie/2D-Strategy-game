using Microsoft.Xna.Framework;

namespace DeiGratia.src.Entities;

public class PlayerCharacter : IEntity
{

    private Vector2 _position;
    private int _healthPoints;
    private int _movementPoints;
    private CharacterState _state;
    
    public int MovementPoints { get; set;}

    public Vector2 Position { get; set;}

    public PlayerCharacter(int x, int y)
    {
        Position = new Vector2(x, y);
        _state = CharacterState.IDLE;
    }
    
    public void Move(Vector2 amount)
    {
        _position += amount;
    }
    
    
    
    
}