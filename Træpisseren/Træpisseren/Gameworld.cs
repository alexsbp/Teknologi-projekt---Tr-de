using Microsoft.Xna.Framework;
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
    public class GameWorld : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Resurser MINE;
        Resurser BackG;
        Resurser BANK;
        static Object dorker = new Object();
        public Thread t1;
        Resurser RS; 

        SpriteFont scoreFont;
        private string scoreText;
        private string MineText;
        public static int score = 1;
        public static int MineScore = 100;

        List<Resurser> ListWOOD;
        List<Resurser> ListBASE;
        List<Resurser> ListWORK;
        private static GameWorld instance;
        public static GameWorld Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameWorld();
                }
                return instance;
            }
        }

        public float deltaTime { get; private set; }

        public static bool SpawnWorker;
        public static bool EzMoneyz;

        public GameWorld()
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
            /*BASE = new Resurser(new Vector2(100, 75), "baseC", SpriteEffects.FlipVertically, 1, Vector2.Zero, 1F, Color.White, 0);
            Thread t = new Thread(BASE.ThreadTest);
            t.Start();*/

            MINE = new Resurser(new Vector2(700, 350), "mineC", SpriteEffects.None, 0, Vector2.Zero, 1F, Color.White, 0,MyType.NotMiner);
            BackG = new Resurser(new Vector2(-100, 100), "BackG", SpriteEffects.None, 0, Vector2.Zero, 1F, Color.White, 0,MyType.NotMiner);
            BANK = new Resurser(new Vector2(100, 350), "bankA", SpriteEffects.None, 1, Vector2.Zero, 1F, Color.White, 0, MyType.NotMiner);

            ListWOOD = new List<Resurser>();
            //ListWOOD.Add(new Resurser(new Vector2(650, 50), "treeB", SpriteEffects.None, 1, Vector2.Zero, 0.3F, Color.White, 0));
            ListWOOD.Add(new Resurser(new Vector2(620, 90), "treeB", SpriteEffects.None, 0.1F, Vector2.Zero, 0.3F, Color.White, 0, MyType.NotMiner));
            ListWOOD.Add(new Resurser(new Vector2(700, 45), "treeB", SpriteEffects.None, 0.3F, Vector2.Zero, 0.3F, Color.White, 0, MyType.NotMiner));
            ListWOOD.Add(new Resurser(new Vector2(600, 20), "treeB", SpriteEffects.None, 0.2F, Vector2.Zero, 0.3F, Color.White, 0, MyType.NotMiner));
            ListWOOD.Add(new Resurser(new Vector2(520, 60), "treeB", SpriteEffects.None, 0.4F, Vector2.Zero, 0.3F, Color.White, 0, MyType.NotMiner));

            ListBASE = new List<Resurser>();
            ListWORK = new List<Resurser>();
            ListBASE.Add(new Resurser(new Vector2(100, 75), "baseC", SpriteEffects.None, 0, Vector2.Zero, 1F, Color.White, 0, MyType.NotMiner));
            ListWORK.Add(new Resurser(new Vector2(136, 145), "B1", SpriteEffects.None, 0.5F, Vector2.Zero, 1F, Color.White, 0, MyType.Miner));
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

            foreach (Resurser WORK in ListWORK)
            {
                WORK.LoadContent(Content);
            }

            MINE.LoadContent(Content);
            BackG.LoadContent(Content);
            BANK.LoadContent(Content);

            scoreFont = Content.Load<SpriteFont>("ScoreFont"); 
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


            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Space) && SpawnWorker && score > 0)
            {
                Resurser work = new Resurser(new Vector2(136, 145), "B1", SpriteEffects.None, 0.5F, Vector2.Zero, 1F, Color.White, 0,MyType.Miner);
                ListWORK.Add(work);
                work.LoadContent(Content);
                SpawnWorker = false;
            }            
            if (keyState.IsKeyUp(Keys.Space) && SpawnWorker == false)
            {
                SpawnWorker = true;
            }

            if (keyState.IsKeyDown(Keys.P) && EzMoneyz) //CHEATS!
            {
                score += 50;
                EzMoneyz = false;
            }
            if (keyState.IsKeyUp(Keys.P) && EzMoneyz == false)
            {
                EzMoneyz = true;
            }

            //foreach (Resurser WORK in ListWORK)
            //{
            //    WORK.Update();
            //}

            scoreText = "Gold: " + " " + score;
            MineText = "Gold Mine: " + " " + MineScore;

            base.Update(gameTime);
        }

        /*static void CreateWorker(object obj)
        {
            Resurser work = new Resurser(new Vector2(136, 145), "B1", SpriteEffects.None, 0.5F, Vector2.Zero, 1F, Color.White, 0);
            GameWorld.Instance.t1 = new Thread(new ParameterizedThreadStart(work.ThreadWorker));
            GameWorld.Instance.t1.Start();
            ListWORK.Add(work);
            work.LoadContent(Content);

            if (work.Position.X > 200)
            {
                Thread.Sleep(1000);
            }
        }*/

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
            
            foreach (Resurser WORK in ListWORK)
            {
                WORK.Draw(spriteBatch);
            }            
            
            foreach (Resurser Wood in ListWOOD)
            {
                Wood.Draw(spriteBatch); 
            }

            spriteBatch.DrawString(scoreFont, scoreText, new Vector2(120, 55), Color.Gold, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
            spriteBatch.DrawString(scoreFont, MineText, new Vector2(700, 330), Color.Gold, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
             
            spriteBatch.End(); 

            base.Draw(gameTime);
        }
    }
}
