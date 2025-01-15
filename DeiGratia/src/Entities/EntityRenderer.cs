using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace DeiGratia.src.Entities;

public class EntityRenderer
{
    public List<IEntity> Entities;

    public List<Texture2D> Textures;

    public EntityRenderer(List<IEntity> entities, List<Texture2D> textures)
    {
        this.Entities = entities;
        this.Textures = textures;
    }

    
}