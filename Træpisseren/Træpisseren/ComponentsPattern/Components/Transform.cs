using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Træpisseren
{
    public class Transform : Component
    {
        /// <summary>
        /// The transform's position
        /// </summary>
        public Vector2 position { get; set; }

        /// <summary>
        /// The transform's constructor
        /// </summary>
        /// <param name="gameObject">Parent object</param>
        /// <param name="position">The transform's position</param>
        public Transform(GameObject gameObject, Vector2 position) : base(gameObject)
        {
            this.position = position;
        }

        public void Translate(Vector2 translation)
        {
            position += translation;
        }

        internal void Translate(object p)
        {
            throw new NotImplementedException();
        }
    }
}
