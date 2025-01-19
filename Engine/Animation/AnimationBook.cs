using Microsoft.Xna.Framework;

namespace Engine
{
    public class AnimationBook : SpriteSheet
    {
        #region Member Variables
        // The time in seconds that has passed since the last frame change
        float timeInSeconds;
        #endregion

        #region Properties
        /// <summary>
        /// Indicates how long in seconds each frame of animation is shown
        /// </summary>
        public float TimePerFrame
        {
            get; protected set;
        }
        /// <summary>
        /// Whether or no the animation should restart when the last frame has passed
        /// </summary>
        public bool IsLooping
        {
            get; protected set;
        }
        /// <summary>
        /// The total number of frames in this animation
        /// </summary>
        public int TotalNumberOfFrames
        {
            get
            {
                return NumberOfSheetElements;
            }
        }
        /// <summary>
        /// Whether or not the animatino has finished playing
        /// </summary>
        public bool HasAnimationEnded
        {
            get
            {
                return (IsLooping && SheetIndex >= TotalNumberOfFrames - 1);
            }
        }

        #endregion

        #region Constructor
        public AnimationBook(string assetName, float layerDepth, bool isLooping, float timePerFrame) : base(assetName, layerDepth)
        {
            IsLooping = isLooping;
            TimePerFrame = timePerFrame;
        }

        #endregion

        #region Public Methods
        public void Play()
        {
            SheetIndex = 0;
            timeInSeconds = 0.0f;
        }
        public void Update(GameTime gameTime)
        {
            timeInSeconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
            // if enough time has passed, go to the next frame
            while (timeInSeconds > TimePerFrame)
            {
                timeInSeconds -= TimePerFrame;
                if (IsLooping == true)
                {
                    SheetIndex = (SheetIndex + 1) % NumberOfSheetElements;
                }
                else
                {
                    SheetIndex = Math.Min(SheetIndex + 1, NumberOfSheetElements - 1);
                }
            }
        }
        #endregion

    }
}
