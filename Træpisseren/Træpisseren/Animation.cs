using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Træpisseren
{
    class Animation
    {
        /// <summary>
        /// This animations fps, higher fps means faster animation
        /// </summary>
        public float FPS { get; private set; }

        /// <summary>
        /// The rectangles associated with this animation
        /// </summary>
        public Rectangle[] Rectangles { get; private set; }

        /// <summary>
        /// The offset for this animation
        /// </summary>
        public Vector2 Offset { get; private set; }

        /// <summary>
        /// The animations constructor
        /// </summary>
        /// <param name="frames">Amount of frames</param>
        /// <param name="yPos">The y-position of the topleft corner of the sprite on the sprite sheet in pixels</param>
        /// <param name="xStartFrames">The frame number from left to right on the sprite sheet (first frame is index 0)</param>
        /// <param name="width">The width of each frame</param>
        /// <param name="height">The height of each frame</param>
        /// <param name="FPS">The FPS for this animation</param>
        /// <param name="offset">The offset for this animation</param>
        public Animation(int frames, int yPos, int xStartFrames, int width, int height, float FPS, Vector2 offset)
        {
            Rectangles = new Rectangle[frames];

            Offset = offset;

            this.FPS = FPS;

            for (int i = 0; i < frames; i++) //Creates the rectangles based on the parameters
            {
                Rectangles[i] = new Rectangle((i + xStartFrames) * width, yPos, width, height);
            }
        }
    }
}
