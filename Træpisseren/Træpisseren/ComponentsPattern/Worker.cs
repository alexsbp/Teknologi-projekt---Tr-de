using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Træpisseren
{
    class Worker : Component, IUpdateable, ILoadable, IAnimateable
    {

        /// <summary>
        /// The player's movement speed
        /// </summary>
        private float speed;

        /// <summary>
        /// A reference to the player's animator
        /// </summary>
        private Animator animator;
        

        public Worker(GameObject gameObject) : base(gameObject)
        {
            speed = 100;
        }

        /// <summary>
        /// Checks for input on the palyer and makes sure that he moves
        /// </summary>
        public void Move()
        {
            //A reference to the current keyboard state
            KeyboardState keyState = Keyboard.GetState();

            //The current translation of the player
            //We are restting it to make sure that he stops moving if not keys are pressed
            Vector2 translation = Vector2.Zero;

            //checks for input and adds it to the translation
            if (keyState.IsKeyDown(Keys.W))
            {
                translation += new Vector2(0, -1);
                animator.PlayAnimation("WalkBack");
            }
            if (keyState.IsKeyDown(Keys.A))
            {
                translation += new Vector2(-1, 0);
                animator.PlayAnimation("WalkLeft");
            }
            if (keyState.IsKeyDown(Keys.S))
            {
                translation += new Vector2(0, 1);
                animator.PlayAnimation("WalkFront");
            }
            if (keyState.IsKeyDown(Keys.D))
            {
                translation += new Vector2(1, 0);
                animator.PlayAnimation("WalkRight");
            }

            //Move the player's gameobject framerate independent
            gameObject.transform.Translate(translation * speed * Gameworld.Instance.deltaTime);
        }

        /// <summary>
        /// Creates all the player's animations
        /// </summary>
        private void CreateAnimations()
        {
            animator.CreateAnimation("IdleFront", new Animation(4, 0, 0, 90, 150, 6, Vector2.Zero));
            animator.CreateAnimation("IdleBack", new Animation(4, 0, 4, 90, 150, 6, Vector2.Zero));
            animator.CreateAnimation("IdleLeft", new Animation(4, 0, 8, 90, 150, 6, Vector2.Zero));
            animator.CreateAnimation("IdleRight", new Animation(4, 0, 12, 90, 150, 6, Vector2.Zero));
            animator.CreateAnimation("WalkFront", new Animation(4, 150, 0, 90, 150, 6, Vector2.Zero));
            animator.CreateAnimation("WalkBack", new Animation(4, 150, 4, 90, 150, 6, Vector2.Zero));
            animator.CreateAnimation("WalkLeft", new Animation(4, 150, 8, 90, 150, 6, Vector2.Zero));
            animator.CreateAnimation("WalkRight", new Animation(4, 150, 12, 90, 150, 6, Vector2.Zero));
            animator.CreateAnimation("AttackFront", new Animation(4, 300, 0, 145, 160, 8, new Vector2(-50, 0)));
            animator.CreateAnimation("AttackBack", new Animation(4, 465, 0, 170, 155, 8, new Vector2(-20, 0)));
            animator.CreateAnimation("AttackRight", new Animation(4, 620, 0, 150, 150, 8, Vector2.Zero));
            animator.CreateAnimation("AttackLeft", new Animation(4, 770, 0, 150, 150, 8, new Vector2(-60, 0)));
            animator.CreateAnimation("DieFront", new Animation(3, 920, 0, 150, 150, 5, Vector2.Zero));
            animator.CreateAnimation("DieBack", new Animation(3, 920, 3, 150, 150, 5, Vector2.Zero));
            animator.CreateAnimation("DieLeft", new Animation(3, 1070, 0, 150, 150, 5, Vector2.Zero));
            animator.CreateAnimation("DieRight", new Animation(3, 1070, 3, 150, 150, 5, Vector2.Zero));

            //Plays an aniamtion to make sure that we have an animation to play
            //If we don't do this we will get an exception
            animator.PlayAnimation("AttackFront");
        }

        public void Update()
        {
            //Makes sure that the player's move function is called
            Move();
        }

        /// <summary>
        /// Loads the player's content
        /// </summary>
        /// <param name="content"></param>
        public void LoadContent(ContentManager content)
        {
            //Sets up a reference to the palyer's animator
            animator = (Animator)gameObject.GetComponent("Animator");

            //We can make our animations when we have a reference to the player's animator.
            CreateAnimations();
        }

        public void OnAnimationDone(string animationName)
        {
            if (animationName.Contains("Attack"))
            {
                //We finished an attack
            }
        }

        /*
        public Worker(GameObject gameObject) : base(gameObject)
        {
            gameObject.Tag = "Worker";
        }

        public void Update()
        {

        }
        */
    }


}
