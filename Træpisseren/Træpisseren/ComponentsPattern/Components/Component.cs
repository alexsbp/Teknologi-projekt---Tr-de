using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Træpisseren
{
    public abstract class Component
    {
        /// <summary>
        /// This component's parent GameObject
        /// </summary>
        public GameObject gameObject { get; private set; }

        /// <summary>
        /// The components constructor
        /// </summary>
        /// <param name="gameObject">The parent GameObject</param>
        public Component(GameObject gameObject)
        {
            this.gameObject = gameObject; //Sets the parent
        }

        public Component()
        {

        }
    }
}
