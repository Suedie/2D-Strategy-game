using Microsoft.Xna.Framework;

namespace DeiGratia.src.Entities;

public class Cavalier : Entity
{
    public Cavalier(int x, int y)
    {
        base.Position = new Vector2(x, y);
        base.State = CharacterState.IDLE;
    }
    
}