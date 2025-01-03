using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    /// <summary>
    /// A class that manages all the objects belonging to a single game state
    /// </summary>
    internal class GameState : IGameLoopObject
    {
        #region Member Variables
        /// <summary>
        /// The game objects associated to this game state
        /// </summary>
        protected GameObjectList gameObjectList;
        #endregion
        #region Constructor
        /// <summary>
        /// Creates a new GameState object with an empty list of GameObjects
        /// </summary>
        protected GameState()
        {
            gameObjectList = new GameObjectList();
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Calls HandleInput for all objects in this GameState.
        /// </summary>
        /// <param name="inputHelper"> An object required for handling player input</param>
        public virtual void HandleInput(InputHelper inputHelper)
        {
            gameObjectList.HandleInput(inputHelper);
        }
        #endregion
        /// <summary>
        /// Draws all the objects in the GameState
        /// </summary>
        /// <param name="gameTime">An object containing informaiton about the time that has passed</param>
        /// <param name="spriteBatch">A sprite batch object used for drawing Sprites</param>
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            gameObjectList.Draw(gameTime, spriteBatch);
        }
        /// <summary>
        /// Calls reset for all the objects in the GameState
        /// </summary>
        public virtual void Reset()
        {
            gameObjectList.Reset();
        }
    }
}
