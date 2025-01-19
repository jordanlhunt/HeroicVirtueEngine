namespace Engine
{
    /// <summary>
    /// A class that can represent a game object with several animated sprites
    /// </summary>
    public class AnimatedGameObject : SpriteGameObject
    {
        #region Member Variables
        Dictionary<string, Animation> animations;
        #endregion
        #region Constructor 
        #endregion
        #region Public Methods
        public void LoadAnimation(string animationName, string animationId, bool isLooping, float frameTime)
        {
            Animation animation = new Animation(animationName, layerDepth, isLooping, frameTime);
            animations[animationId] = animation;
        }
        public void PlayAnimation(string animationId, bool isForceRestart = false, int startSheetIndex = 0)
        {
            // if the annimation is already playing don't do anything
            if (!isForceRestart == false && sprite == animations[animationId])
            {
                return;
            }
            animations[animationId].Play(startSheetIndex);
            sprite = animations[animationId];
        }
        #endregion
    }
}
