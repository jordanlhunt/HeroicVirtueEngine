namespace Engine.Animation
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
        public Animation(string assetName, float layerDepth, bool isLooping, float timePerFrame) : base(assetName, layerDepth)
        {
            IsLooping = isLooping;
            TimePerFrame = timePerFrame;
            TimePerFrame = timePerFrame;
        }

        #endregion

        #region Public Methods
        #endregion

    }
}
