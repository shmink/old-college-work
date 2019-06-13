using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using NextLevelEngine.Graphics;

namespace NextLevelEngine.Projectile
{
    public class bullets
    {
        public int w, h, x, y;
        public Texture2D image;
        public int rate;
        public bool alive;
        public Rectangle boundary;

        
        public void LoadContent(ContentManager content, string assetName)
        {
            image = content.Load<Texture2D>(assetName);

            w = image.Width;
            h = image.Height;
            boundary = new Rectangle(x, y, w, h);
        }

        public void Update()
        {
            y -= 10;
        }

        public Boolean isAlive()
        {
            if (x < boundary.X && x > boundary.Width || y < boundary.Y && y > boundary.Height)
                return false;
            else
                return true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, new Rectangle(x, y, w, h), Color.White);
        }
    }
}