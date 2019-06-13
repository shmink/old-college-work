using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace NextLevelEngine.Graphics
{
    public class Player
    {
        public Texture2D texture;
        public Vector2 position;
        public Rectangle boundaries;
        public float speed;

        public Player(Texture2D newTexture, Vector2 newPosition)
        {
            texture = newTexture;
            position = newPosition;
            boundaries = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
 
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, boundaries, Color.White);
        }
    }
}
