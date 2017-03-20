using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Træpisseren
{
    public class GameObject : Component
    {
        private bool isLoaded = false;

        /// <summary>
        /// The GameObject's transform
        /// </summary>
        public Transform transform;

        /// <summary>
        /// A list that contains all components on this GameObject
        /// </summary>
        private List<Component> components = new List<Component>();

        /// <summary>
        /// The tag of this GameObject
        /// </summary>
        public string Tag { get; set; } = "Untagged";

        public GameObject()
        {
            this.transform = new Transform(this, Vector2.Zero); //Adds a transform component to the GameObject

            AddComponent(transform);
        }

        /// <summary>
        /// Adds a component to the GameObject
        /// </summary>
        /// <param name="component">The component to add</param>
        public void AddComponent(Component component)
        {
            components.Add(component); 
        }

        /// <summary>
        /// Returns the specified component if it exists
        /// </summary>
        /// <param name="component">The component to find</param>
        /// <returns></returns>
        public Component GetComponent(string component)
        {
            return components.Find(n => n.GetType().Name == component);
        }

        /// <summary>
        /// Loads the GameObject's content, this is where we load sounds, sprites etc.
        /// </summary>
        /// <param name="content">The Content from the GameWorld</param>
        public void LoadContent(ContentManager content)
        {
            if (!isLoaded) //To prevent double loading of assets
            {
                foreach (Component component in components)
                {
                    if (component is ILoadable)
                    {
                        (component as ILoadable).LoadContent(content);
                    }
                }
                isLoaded = true; //LoadContent is only used once                
            }
        }

        /// <summary>
        /// Updates all GameObject's components
        /// </summary>
        public void Update()
        {
            foreach (Component component in components) //Updates all updatable components
            {
                if (component is IUpdateable)
                {
                    (component as IUpdateable).Update();
                }
            }
        }

        /// <summary>
        /// Draws the GameObject
        /// </summary>
        /// <param name="spritebatch">The spritebatch from our GameWorld</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            //spritebatch.Draw(sprite, transform.Position, Color.White);
            foreach (Component component in components)
            {
                if (component is IDrawable)
                {
                    (component as IDrawable).Draw(spriteBatch);
                }
            }
        }

        /// <summary>
        /// Executed when an animation has finished playing
        /// </summary>
        /// <param name="animationName">The name of the animation</param>
        public void OnAnimationDone(string animationName)
        {
            foreach (Component component in components)
            {
                if (component is IAnimateable) //Checks if any components are IAnimateable
                {
                    (component as IAnimateable).OnAnimationDone(animationName); //If a component is IAnimateable, call the local implementation of the method
                }
            }
        }
    }
}
