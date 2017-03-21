﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading; 

namespace Træpisseren
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Gameworld : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Resurser MINE;
        Resurser BackG;
        Resurser BANK;
        Resurser WORK;
       
        List<Resurser> ListWOOD;
        List<Resurser> ListBASE;
        List<Resurser> ListTEST;
        private static Gameworld instance;
        public static Gameworld Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Gameworld();
                }
                return instance;
            }
        }

        public float deltaTime { get; private set; }

        public Gameworld()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 650;             
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {        
            MINE = new Resurser(new Vector2(700, 350), "mineC", SpriteEffects.None, 1, Vector2.Zero, 1F, Color.White, 0);

            /*BASE = new Resurser(new Vector2(100, 75), "baseC", SpriteEffects.FlipVertically, 1, Vector2.Zero, 1F, Color.White, 0);
            Thread t = new Thread(BASE.ThreadTest);
            t.Start();*/

            MINE = new Resurser(new Vector2(700, 350), "mineC", SpriteEffects.None, 1, Vector2.Zero, 1F, Color.White, 0);
            BackG = new Resurser(new Vector2(-100, 100), "BackG", SpriteEffects.None, 0, Vector2.Zero, 1F, Color.White, 0);
            BANK = new Resurser(new Vector2(100, 350), "bankA", SpriteEffects.None, 0, Vector2.Zero, 1F, Color.White, 0);
            WORK = new Resurser(new Vector2(136, 145), "A1", SpriteEffects.None, 1, Vector2.Zero, 1F, Color.White, 0);

            ListWOOD = new List<Resurser>();
            ListWOOD.Add (new Resurser(new Vector2(650, 50), "treeB", SpriteEffects.None, 1, Vector2.Zero, 0.3F, Color.White, 0));
            ListWOOD.Add (new Resurser(new Vector2(600, 90), "treeB", SpriteEffects.None, 1, Vector2.Zero, 0.3F, Color.White, 0));
            ListWOOD.Add (new Resurser(new Vector2(700, 45), "treeB", SpriteEffects.None, 1, Vector2.Zero, 0.3F, Color.White, 0));
            ListWOOD.Add (new Resurser(new Vector2(600, 20), "treeB", SpriteEffects.None, 1, Vector2.Zero, 0.3F, Color.White, 0));
            ListWOOD.Add (new Resurser(new Vector2(520, 60), "treeB", SpriteEffects.None, 1, Vector2.Zero, 0.3F, Color.White, 0));

            ListTEST = new List<Resurser>();
            ListBASE = new List<Resurser>();
            ListBASE.Add(new Resurser(new Vector2(100, 75), "baseC", SpriteEffects.None, 1, Vector2.Zero, 1F, Color.White, 0));
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);


            foreach (Resurser WOOD in ListWOOD)
            {
                WOOD.LoadContent(Content); 
            }

            foreach (Resurser BASE in ListBASE)
            {
                BASE.LoadContent(Content);
            }
            foreach (Resurser tst in ListTEST)
            {
                tst.LoadContent(Content); 
            }
            MINE.LoadContent(Content);
            BackG.LoadContent(Content);
            BANK.LoadContent(Content);
            WORK.LoadContent(Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            WORK.Update();

            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Space))
            {
                foreach (Resurser BASE in ListBASE)
                {
                    Resurser rs = new Resurser(new Vector2(BASE.Position.X, 100), "B1", SpriteEffects.FlipVertically, 1, Vector2.Zero, 1F, Color.White, 0);
                    ListTEST.Add(rs);
                    rs.LoadContent(Content);
                    rs.Update(); 
                    /*Thread t = new Thread(rs.ThreadTest);
                    t.Start();*/
                }
                
            }
            

            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);

            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
            foreach (Resurser BASE in ListBASE)
            {
                BASE.Draw(spriteBatch);
            }

            MINE.Draw(spriteBatch);
            BackG.Draw(spriteBatch);
            BANK.Draw(spriteBatch);
            WORK.Draw(spriteBatch);
            

            foreach (Resurser tst in ListTEST)
            {
                tst.Draw(spriteBatch); 
            }
            foreach (Resurser Wood in ListWOOD)
            {
                Wood.Draw(spriteBatch); 
            }

            spriteBatch.End(); 

            base.Draw(gameTime);
        }
    }
}
