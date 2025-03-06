
using Microsoft.Xna.Framework;

namespace Engine
{
    public class Animation : SpriteSheet
    {

        #region Member Variables
        /// <summary>
        /// The seconds that has passed since the last frame change
        /// </summary>
        float time;
        #endregion
        #region Properties
        /// <summary>
        /// Indications how long in seconds each frame of the animation is shown
        /// </summary>
        public float TimePerFrame
        {
            get; protected set;
        }
        /// <summary>
        /// Flag for if the animation should restart when the frame has passed
        /// </summary>
        public bool IsLooping
        {
            get; protected set;
        }
        /// <summary>
        /// The total number of frames in this animation
        /// </summary>
        public int NumberOfFrames
        {
            get
            {
                return base.NumberOfSheetElements;
            }
        }
        /// <summary>
        /// Flag for if the animation has finished playing
        /// </summary>
        public bool HasAnimationEnded
        {
            get
            {
                return !IsLooping && SheetIndex >= NumberOfFrames - 1;
            }
        }
        #endregion

        #region Constructor
        public Animation(string assetname, float layerDepth, bool looping, float timePerFrame) : base(assetname, layerDepth)
        {
            IsLooping = looping;
            TimePerFrame = timePerFrame;
        }
        #endregion

        #region Public Methods
        #endregion
        public void Play(int startSheetIndex)
        {
            SheetIndex = startSheetIndex;
            time = 0.0f;
        }

        public void Update(GameTime gameTime)
        {
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;

            // if enough time has passed, go to the next frame
            while (time > TimePerFrame)
            {
                time -= TimePerFrame;

                if (IsLooping == true)
                {
                    // go to the next frame, or loop around
                    SheetIndex = (SheetIndex + 1) % NumberOfSheetElements;
                }
                else
                {
                    // go to the next frame if it exists
                    SheetIndex = Math.Min(SheetIndex + 1, NumberOfSheetElements - 1);
                }
            }
        }
    }
}
