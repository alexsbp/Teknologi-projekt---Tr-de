using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Threading;

namespace Træpisseren
{
    enum MyType
    {
        Miner,
        NotMiner
    }
    class Resurser
    {
        private int positionPoint = 0;
        private int bankPoint = 0;
        private int deathPoint = 0;
        public bool running = true;
        Thread t1;
        MyType type;
        private Vector2 position;
        public Vector2 Position
        {
            get
            {
                return position;
            }
        }

        private Texture2D sprite;
        private string spritestring;
        private SpriteEffects effects;
        private float layer;
        private Vector2 origin = Vector2.Zero;
        private float scale;
        private Color color;
        private float rotation;
        private Thread Thread1; 

        public Resurser(Vector2 position, string sprite, SpriteEffects effect, float layer, Vector2 origin, float scale, Color color, float rotation,MyType type)
        {
            this.position = position;
            this.spritestring = sprite;
            this.effects = effect;
            this.layer = layer;
            this.origin = origin;
            this.scale = scale;
            this.color = color;
            this.rotation = rotation;
            this.type = type;
            if(type == MyType.Miner)
            { 
            this.t1 = new Thread(ThreadWorker);
            this.t1.IsBackground = true;
            this.t1.Start();
            }
        }

        public void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>(spritestring);
        }

        public void Update()
        {
            if (positionPoint == 0 && bankPoint == 0 && deathPoint == 0 || positionPoint == 0 && bankPoint == 0 && deathPoint == 1 || positionPoint == 0 && bankPoint == 0 && deathPoint == 2)
            {
                WalkMine();
            }
            if (positionPoint == 1)
            {
                WalkBase();
            }
            if (positionPoint == 2)
            {
                position.X = 136; //Resets the worker's position briefly
                position.Y = 145;
                positionPoint -= 2; //Makes sure the worker won't go to the mine, before visiting the bank
                bankPoint += 2; //Makes it so the worker walks to the bank
            }
            if (positionPoint == 0 && bankPoint == 2)
            {
                WalkBank();
            }
            if (positionPoint == 0 && bankPoint == 1)
            {
                WalkHome();
            }
            if (positionPoint == 0 && bankPoint == 0 && deathPoint == 3)
            {
                WalkDie(); //After the worker has done the same routine 3 times, the worker will go to the woods to die
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(sprite, position, null, color, rotation, origin, scale, SpriteEffects.FlipHorizontally, layer);
        }

        public void ThreadWorker(object obj)
        {
            GameWorld.score -= 1;
            while (running)
            {
                Update();
            }             
        }

        public void WalkMine()
        {
            Thread.Sleep(10);
            if (position.X <= 300 && position.Y >= 100)
            {
                position.X += 3;
            }
            if (position.X >= 300 && position.Y >= 100)
            {
                position.Y += 3;
            }
            if (position.X >= 300 && position.Y >= 350)
            {
                position.X += 3;
                position.Y -= 3;
            }
            if (position.X > 710)
            {
                lock (this)
                {
                    this.layer = 0;
                    GameWorld.Instance.t1.Join(1000); 
                }
                GameWorld.MineScore -= 1;
                if (GameWorld.MineScore == 0)
                {
                    //Insert here
                }
                
                positionPoint += 1;
            }
        }
        public void WalkBase()
        {
            Thread.Sleep(10);
            if (position.X < 750 && position.Y < 350)
            {
                position.X -= 3;
            }
            if (position.X < 340 && position.Y >= 146)
            {
                position.Y -= 3;
                position.X += 3;
            }
            if (position.X >= 330 && position.Y < 146)
            {
                position.X -= 3;
            }
            if (position.X < 140)
            {
                positionPoint += 1;
            }
        }
        public void WalkBank()
        {
            Thread.Sleep(10);
            if (position.X < 140 && position.Y < 440)
            {
                position.Y += 3;
            }
            if (position.X < 140 && position.Y > 430)
            {
                bankPoint -= 1;
            }
        }
        public void WalkHome()
        {
            Thread.Sleep(10);
            if (position.X < 140 && position.Y >= 146)
            {
                position.Y -= 3;
            }
            if (position.X < 140 && position.Y <= 146)
            {
                bankPoint -= 1;
                GameWorld.score += 1;
                deathPoint += 1;
            }
        }
        public void WalkDie()
        {
            Thread.Sleep(10);
            if (position.X < 720 && position.Y >= 50)
            {
                position.X += 3;
            }
            if (position.X >= 720 && position.Y >= 50)
            {                
                running = false;
            }
        }
    }
}
