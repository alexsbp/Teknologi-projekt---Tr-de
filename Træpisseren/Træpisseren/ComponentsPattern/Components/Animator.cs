using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Træpisseren
{
    class Animator : Component, IUpdateable
    {
        /// <summary>
        /// The current index of the animation
        /// </summary>
        private int currentIndex;

        /// <summary>
        /// Time elapsed for the current animation
        /// </summary>
        private float timeElapsed;

        /// <summary>
        /// The framerate of the animation
        /// </summary>
        private float fps;

        /// <summary>
        /// The rectangle on the spritesheet
        /// </summary>
        private Rectangle[] rectangles;

        /// <summary>
        /// A reference to the spriteRenderer
        /// </summary>
        private SpriteRenderer spriteRenderer;

        public Dictionary<string, Animation> animations;

        private string animationName;

        public Animator(GameObject gameObject) : base(gameObject)
        {
            this.spriteRenderer = (SpriteRenderer)gameObject.GetComponent("SpriteRenderer");

            this.animations = new Dictionary<string, Animation>();
        }

        public void Update()
        {
            timeElapsed += GameWorld.Instance.deltaTime;

            currentIndex = (int)(timeElapsed * fps);

            if (currentIndex > rectangles.Length - 1)
            {
                gameObject.OnAnimationDone(animationName);
                timeElapsed = 0;
                currentIndex = 0;
            }

            spriteRenderer.Rectangle = rectangles[currentIndex];
        }

        /// <summary>
        /// Adds a new animation
        /// </summary>
        /// <param name="name">Animation name</param>
        /// <param name="animation">The animation to add</param>
        public void CreateAnimation(string name, Animation animation)
        {
            animations.Add(name, animation); //Adds a new animation to the dictionary
        }

        /// <summary>
        /// Plays an animation
        /// </summary>
        /// <param name="animationName">Name of animation to play</param>
        public void PlayAnimation(string animationName)
        {
            if (this.animationName != animationName) //Checks if it's a new animation
            {
                this.rectangles = animations[animationName].Rectangles; //Sets the rectangles

                this.spriteRenderer.Rectangle = rectangles[0]; //Sets the size of the rectangle

                this.spriteRenderer.Offset = animations[animationName].Offset; //Sets the offset

                this.animationName = animationName; //Sets the animation name

                this.fps = animations[animationName].FPS; //Sets the fps

                timeElapsed = 0; //Resets the animation
                currentIndex = 0;
            }
        }
    }
}
