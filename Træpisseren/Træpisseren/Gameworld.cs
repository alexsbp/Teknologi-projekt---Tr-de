using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Træpisseren
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Gameworld : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Resurser BASE;
        Resurser MINE;
        Resurser BackG;
        List<Resurser> ListWOOD; 

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
            graphics.PreferredBackBufferWidth = 1001;
            graphics.PreferredBackBufferHeight = 701;
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            BASE = new Resurser(new Vector2(100, 75), "baseC", SpriteEffects.None, 0, Vector2.Zero, 1F, Color.White, 0);
            MINE = new Resurser(new Vector2(650, 400), "mineC", SpriteEffects.None, 0, Vector2.Zero, 1F, Color.White, 0);
            BackG = new Resurser(new Vector2(0, 0), "BackG", SpriteEffects.None, 0, Vector2.Zero, 1F, Color.White, 0);

            ListWOOD = new List<Resurser>(); 
            ListWOOD.Add (new Resurser(new Vector2(650, 50), "treeB", SpriteEffects.None, 1, Vector2.Zero, 0.3F, Color.White, 0));
            ListWOOD.Add (new Resurser(new Vector2(600, 90), "treeB", SpriteEffects.None, 1, Vector2.Zero, 0.3F, Color.White, 0));
            ListWOOD.Add (new Resurser(new Vector2(700, 45), "treeB", SpriteEffects.None, 1, Vector2.Zero, 0.3F, Color.White, 0));
            ListWOOD.Add (new Resurser(new Vector2(600, 20), "treeB", SpriteEffects.None, 1, Vector2.Zero, 0.3F, Color.White, 0));
            ListWOOD.Add (new Resurser(new Vector2(520, 60), "treeB", SpriteEffects.None, 1, Vector2.Zero, 0.3F, Color.White, 0));

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
            BASE.LoadContent(Content);
            MINE.LoadContent(Content);
            BackG.LoadContent(Content);
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
            BASE.Draw(spriteBatch);
            MINE.Draw(spriteBatch);
            BackG.Draw(spriteBatch);

            foreach (Resurser Wood in ListWOOD)
            {
                Wood.Draw(spriteBatch); 
            }
            spriteBatch.End(); 

            base.Draw(gameTime);
        }
    }
}
