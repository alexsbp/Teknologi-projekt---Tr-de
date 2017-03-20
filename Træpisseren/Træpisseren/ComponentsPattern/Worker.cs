using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Træpisseren
{
    class Worker : Component, IUpdateable
    {
        public Worker(GameObject gameObject) : base(gameObject)
        {
            gameObject.Tag = "Worker";
        }

        public void Update()
        {

        }
    }
}
