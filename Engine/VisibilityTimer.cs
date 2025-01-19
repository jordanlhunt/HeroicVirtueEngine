using Microsoft.Xna.Framework;

namespace Engine
{
    /// <summary>
    /// An object taht can make another object visible for a certain amount of time
    /// </summary>
    public class VisibilityTimer : GameObject
    {
        #region Member Variables
        protected GameObject target;
        protected float timeLeft;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Timer with a give target Object
        /// </summary>
        /// <param name="target">The game object whose visiblity you want to manage</param>
        public VisibilityTimer(GameObject target)
        {
            timeLeft = 0;
            this.target = target;
        }
        public override void Update(GameTime gameTime)
        {
            if (timeLeft <= 0)
            {
                return;
            }
            // if enough time has passed, make the target object invisible
            timeLeft -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timeLeft <= 0)
            {
                target.IsVisible = false;
            }
        }
        /// <summary>
        /// Makes the target object visible, and starts a timer for the specified number of seconds.
        /// </summary>
        /// <param name="seconds">How long the target object should be visible.</param>
        public void StartVisible(float seconds)
        {
            timeLeft = seconds;
            target.IsVisible = true;
        }
        #endregion
    }
}
