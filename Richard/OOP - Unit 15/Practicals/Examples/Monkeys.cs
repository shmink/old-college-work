using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;


namespace Birdie_in_spaaaaaaceV2._0
{
    public class Monkeys
    {
        //variables
        public Texture2D texture;
        public Vector2 position;
        public Rectangle monkeyBox;
        public Vector2 origin;
        public float rotate;
        public int speed;
        public bool isColliding, destroy;

        //setting up some data for the variables such as the spawns outside of the viewport and then
        //moves onto the screen
        public Monkeys()
        {
            //this two lines create a random number between 0 - 480 (screenHeight) giving the enemy more
            //random spawning on the y axis
            Random r = new Random();
            int nextValue = r.Next(0, 480);

            position = new Vector2(800, nextValue);
            texture = null;
            speed = 4;
            isColliding = false;
            destroy = false;
        }

        //loading the monkey texture and giving the origin variable some data, origin will serve as a pivot point
        //for the texture to spin on
        public void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("monkey");
            origin.X = texture.Width / 2;
            origin.Y = texture.Height / 2;
        }

        //Here is the update routine for the monkey 
        public void Update(GameTime gameTime)
        {
            //This sets up a bounding box for the monkey so collisions can be detected
            monkeyBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            //Here the position of the monkey is moving to the left and resets once it goes of screen
            position.X = position.X - speed;
            if (position.X <= -50)
                position.X = 800;


            //rotating the monkey using the pi function to get a smooth rotation
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            rotate += elapsed;
            float circle = MathHelper.Pi * 4;
            rotate = rotate % circle;

        }

        //drawing the monkey was a little mpre complex
        public void Draw(SpriteBatch spriteBatch)
        {
            //if the destroy boolean is true then draw the following.
            //this longer draw function was needed to use the variables rotate and origin
            if (!destroy)
                spriteBatch.Draw(texture, position, null, Color.White, rotate, origin, 1.0f, SpriteEffects.None, 0f);
        }
    }
}
