using System.Collections.Generic;
using System.Numerics;
using DeiGratia.src.Entities;

namespace DeiGratia.src.Model;

public class Cursor
{
    public Vector2 Position;
    public List<IEntity> SelectableEntities { get; } = new List<IEntity>();
    public IEntity SelectedEntity { get; set; }

    public Cursor(Vector2 position, List<IEntity> selectableEntities)
    {
        
    }

    public void MoveCursor(Vector2 position)
    {
        Position += position;
    }

    public void Select(IEntity currentEntity)
    {
        SelectedEntity = currentEntity;
    }
    
    
}