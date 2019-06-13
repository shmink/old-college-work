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

namespace GameState
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D bulletTexture;
        int x, y, w, h;

        SpriteFont myFont;

        enum GameState
        {
            Menu = 0,
            Play = 1,
            Exit = 2
        };

        GameState gameState = new GameState(); //Instance

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            bulletTexture = this.Content.Load<Texture2D>("bullet");
            x = 100; y = 100; w = bulletTexture.Width; h = bulletTexture.Height;

            myFont = this.Content.Load<SpriteFont>("font");
            // TODO: use this.Content to load your game content here
        }

        
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.S))
                gameState = GameState.Play;

            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            //menu
            if (GameState.Menu == gameState)
            {
                spriteBatch.DrawString(myFont, "MENU", new Vector2(350, 10), Color.Black);
                spriteBatch.DrawString(myFont, "S -> Start", new Vector2(350, 100), Color.Black);
                spriteBatch.DrawString(myFont, "E -> Exit", new Vector2(350, 150), Color.Black);
            }
            else
            {
                spriteBatch.Draw(bulletTexture, new Rectangle(x, y, w, h), Color.White); 
            }
            

            

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
