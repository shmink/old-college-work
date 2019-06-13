using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;

namespace Birdie_in_spaaaaaaceV2._0
{
    public class bullets
    {
        //bullets variables
        public Texture2D texture;
        public Rectangle bulletBox;
        public Vector2 position;
        public Vector2 origin;
        public bool isVisible;
        public float speed;
        //in this bullets routine I set up some of the variables for future use
        public bullets(Texture2D newTexture)
        {
            texture = newTexture;
            isVisible = false;
            speed = 10;
        }
        //Here is the draw function for the bullet texture
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
