﻿using Microsoft.Xna.Framework;

namespace Engine
{
    /// <summary>
    /// A class that can represent a game object with several animated sprites
    /// </summary>
    public class AnimatedGameObject : SpriteGameObject
    {
        #region Member Variables
        private Dictionary<string, Animation> animations;
        #endregion
        #region Constructor 
        public AnimatedGameObject(float layerDepth) : base(null, layerDepth)
        {
            animations = new Dictionary<string, Animation>();
        }

        #endregion
        #region Public Methods
        public void LoadAnimation(string animationName, string animationId, bool isLooping, float frameTime)
        {
            Animation animation = new Animation(animationName, layerDepth, isLooping, frameTime);
            animations[animationId] = animation;
        }
        public void PlayAnimation(string animationId, bool isForceRestart = false, int startSheetIndex = 0)
        {
            // if the animation is already playing don't do anything
            if (isForceRestart || sprite != animations[animationId])
            {
                animations[animationId].Play(startSheetIndex);
                sprite = animations[animationId];
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (sprite != null)
            {
                ((Animation)sprite).Update(gameTime);
            }
        }
        #endregion
    }
}
