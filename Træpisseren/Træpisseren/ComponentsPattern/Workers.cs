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
    class Workers : Component, IUpdateable
    {
        public Workers(GameObject gameObject) : base(gameObject)
        {
            gameObject.Tag = "Workers";
        }

        public void Update()
        {

        }
    }
}
