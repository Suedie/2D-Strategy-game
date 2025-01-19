using System;
using Microsoft.Xna.Framework;

namespace DeiGratia.src.Entities;

public abstract class Entity : IEntity
{
    public Vector2 Position { get; set; }
    private int _healthPoints;
    private int _movementPoints;
    public CharacterState State { get; set; }
    public String Name { get; set; }
    
    public void Move(Vector2 amount)
    {
        Position += amount;
    }
}