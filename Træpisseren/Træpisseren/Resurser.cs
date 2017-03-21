﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Træpisseren
{
    class Resurser
    {
        private int positionPoint = 0;        

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

        public Resurser(Vector2 position, string sprite, SpriteEffects effect, float layer, Vector2 origin, float scale, Color color, float rotation)
        {
            this.spritestring = sprite;
            this.position = position;
            this.effects = effect;
            this.layer = layer;
            this.origin = origin;
            this.scale = scale;
            this.color = color;
            this.rotation = rotation;
        }

        public void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>(spritestring);
        }

        public void Update()
        {
            if (positionPoint == 0)
            {
                WalkMine();
            }
            if (positionPoint == 1)
            {
                WalkBase();
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(sprite, position, null, color, rotation, origin, scale, SpriteEffects.FlipHorizontally, layer);
        }

        public void ThreadTest()
        {
            new Resurser(position, spritestring, SpriteEffects.None, layer, origin, scale, Color.White, rotation);
            Update();
        }

        private void WalkMine()
        {
            if (position.X <= 300 && position.Y >= 100)
            {
                position.X += 5;
            }
            if (position.X >= 300 && position.Y >= 100)
            {
                position.Y += 5;
            }
            if (position.X >= 300 && position.Y >= 350)
            {
                position.X += 5;
                position.Y -= 5;
            }
            if (position.X > 710)
            {
                positionPoint += 1;
            }
        }

        private void WalkBase()
        {
            if (position.X < 750 && position.Y < 710)
            {
                position.X -= 10;
            }
        }
    }
}
