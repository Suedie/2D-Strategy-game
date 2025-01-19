using System;
using Microsoft.Xna.Framework;

namespace DeiGratia.src.Entities;

public interface IEntity
{ 
    String Name { get; set; }
    Vector2 Position { get; set; }
    
    void Move(Vector2 delta);
}