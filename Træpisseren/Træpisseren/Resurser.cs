using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Træpisseren
{
    class Resurser
    {
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

        public Resurser(Vector2 position, string sprite)
        {
            this.spritestring = sprite;
            this.position = position; 
        }



    }
}
