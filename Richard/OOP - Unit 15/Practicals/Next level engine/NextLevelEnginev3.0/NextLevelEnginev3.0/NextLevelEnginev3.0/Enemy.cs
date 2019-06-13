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
    public class Enemy : Player//inheriting the player class
    {
        public bool enemyVisble = true;
        Random random = new Random();
        int randY;

        public Enemy(Texture2D newTexture, Vector2 newPosition)
            : base(newTexture, newPosition) //inheriting the player class
        {
            //giving the enemy a random speed, somwhere between 1 and 4
            randY = random.Next(1, 4);
            speed = randY;
            enemyVisble = true; 
        }

        public void Update(GraphicsDevice graphics)
        {
            /*updating the Y direction of the enemy so it comes
            from top to bottom of the screen*/
            position.Y += speed;
            //if the enemy goes of the screen it'll be destroyed
            if (position.Y > 500)
                enemyVisble = false;

        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(texture, position, Color.White);
            enemyVisble = true;

        }
    }
}
