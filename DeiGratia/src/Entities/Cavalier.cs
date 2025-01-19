using Microsoft.Xna.Framework;

namespace DeiGratia.src.Entities;

public class Cavalier : Entity
{
    public Cavalier(int x, int y)
    {
        base.Name = "Cavalier";
        base.Position = new Vector2(x, y);
        base.State = CharacterState.IDLE;
    }
    
}