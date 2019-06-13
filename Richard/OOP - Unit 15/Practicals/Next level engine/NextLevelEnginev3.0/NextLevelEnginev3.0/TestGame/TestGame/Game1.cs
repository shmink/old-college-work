using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using NextLevelEngine.Graphics;
using NextLevelEngine.Projectile;
using NextLevelEngine.Audio;

namespace TestGame
{
    
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //player
        Player myPlayer;
        public Texture2D healthTexture;
        public int health = 200;
        public Rectangle healthRectangle;
        SpriteFont myFont;
        int score = 0;
        string scoreString;
        string timeTaken;
        float t;

        //enemy
        List<Enemy> enemyList = new List<Enemy>();
        Random random2 = new Random();
        float spawn = 0;

        //Bullet
        bullets myBullet = new bullets();
        ArrayList bulletArray = new ArrayList();
        bool hasFired;
        Texture2D bulletImage;

        //Background
        ParallaxingBackground bgLayer1 = new ParallaxingBackground();
        ParallaxingBackground bgLayer2 = new ParallaxingBackground();
        Texture2D mainBackground;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        
        protected override void Initialize()
        {
            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //player asset and properties
            myPlayer = new Player(Content.Load<Texture2D>("player"), new Vector2(400, 400));
            myPlayer.boundaries.Width /= 3;
            myPlayer.boundaries.Height /= 3;
            myPlayer.speed = 5;
            //bullet asset and properties
            bulletImage = Content.Load<Texture2D>("bullet");
            //background asset and properties
            bgLayer1.Initialize(Content, "bgLayer1", GraphicsDevice.Viewport.Width, -1);
            bgLayer2.Initialize(Content, "bgLayer2", GraphicsDevice.Viewport.Width, -2);
            mainBackground = Content.Load<Texture2D>("mainbackground");
            //health properties
            healthTexture = Content.Load<Texture2D>("healthbar");
            myFont = Content.Load<SpriteFont>("SpriteFont1");
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

       
        protected override void Update(GameTime gameTime)
        {
            //controls for the player
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.D) && myPlayer.boundaries.X < (GraphicsDevice.Viewport.Width - myPlayer.boundaries.Width))
                myPlayer.boundaries.X += (int)myPlayer.speed;
            if (Keyboard.GetState().IsKeyDown(Keys.A) && myPlayer.boundaries.X > 0)
                myPlayer.boundaries.X -= (int)myPlayer.speed;
            if (Keyboard.GetState().IsKeyDown(Keys.S) && myPlayer.boundaries.Y < (GraphicsDevice.Viewport.Height - myPlayer.boundaries.Height))
                myPlayer.boundaries.Y += (int)myPlayer.speed;
            if (Keyboard.GetState().IsKeyDown(Keys.W) && myPlayer.boundaries.Y > 0)
                myPlayer.boundaries.Y -= (int)myPlayer.speed;

            //bullets
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && hasFired == false)
            {
                CreateBullet();
                hasFired = true;
            }

            if (Keyboard.GetState().IsKeyUp(Keys.Space)) //if statement to stop too many bullets on screen at once.
                hasFired = false;

            //update bullets
            foreach (bullets b in bulletArray)
            {
                b.Update();
            }

            //enemy update
            spawn += (float)gameTime.ElapsedGameTime.TotalSeconds;
            foreach (Enemy e in enemyList)
                e.Update(graphics.GraphicsDevice);
            LoadEnemies();

            //background updates
            bgLayer1.Update();
            bgLayer2.Update();

            //collision updates
            foreach (Enemy e in enemyList)
            {
                if (myPlayer.boundaries.Intersects(e.boundaries))
                    health -= 10;
            }

            foreach (Enemy e in enemyList)
            {
                if (myBullet.boundary.Intersects(e.boundaries))
                {
                    bulletArray.Remove(myBullet);
                    e.enemyVisble = false;
                }
            }

            //hud updates
            healthRectangle = new Rectangle(80, 10, health, healthTexture.Height);

            t += (float)gameTime.ElapsedGameTime.TotalSeconds;
            timeTaken = Convert.ToString(t);

            scoreString = score.ToString();

            base.Update(gameTime);
        }

        public void LoadEnemies()
        {
            int randX = random2.Next(10, 540); //gives the enemies a random spawn location on the x axis between 10 & 540

            if (spawn <= 1)
            {
                spawn = 0;
                //limits amount of enemies on screen to 5.
                if (enemyList.Count() < 5)
                    enemyList.Add(new Enemy(Content.Load<Texture2D>("enemy"), new Vector2(randX, -100)));
            }
            for (int i = 0; i < enemyList.Count; i++)
            {
                if (!enemyList[i].enemyVisble)
                {
                    //removes the enemies when they go off screen.
                    enemyList.RemoveAt(i);
                    i--;
                }

            }
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            //background drawing
            spriteBatch.Draw(mainBackground, Vector2.Zero, Color.White);
            bgLayer1.Draw(spriteBatch);
            bgLayer2.Draw(spriteBatch);

            //player drawing
            myPlayer.Draw(spriteBatch);
            //enemy drawing
            foreach (Enemy e in enemyList)
            {
                e.Draw(spriteBatch);
            }
            //bullet drawing
            foreach (bullets b in bulletArray)
            {
                b.Draw(spriteBatch);
            }

            //health
            //And here is where the healthbar is drawn
            spriteBatch.Draw(healthTexture, healthRectangle, Color.White);
            //Here I am drawing the font to the screen using the string health,
            //this'll be to the left of the health bar.
            spriteBatch.DrawString(myFont, "Health:", new Vector2(10, 10), Color.White);
            //time taken string
            spriteBatch.DrawString(myFont, "Time:", new Vector2(600, 10), Color.White);
            spriteBatch.DrawString(myFont, timeTaken, new Vector2(650, 10), Color.White);
            //score string
            spriteBatch.DrawString(myFont, "Score:", new Vector2(350, 10), Color.White);
            spriteBatch.DrawString(myFont, "0", new Vector2(410, 10), Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        private void CreateBullet()
        {
            //bullet properties
            myBullet = new bullets();
            myBullet.image = bulletImage;
            myBullet.rate = 100;
            myBullet.w = 5;
            myBullet.h = 10;

            //where the bullet will spawn
            myBullet.x = Convert.ToInt32(myPlayer.boundaries.X + 45);
            myBullet.y = Convert.ToInt32(myPlayer.boundaries.Y);

            //add an instance of the bullet class to the bullet array
            bulletArray.Add(myBullet);
        }
    }
}
