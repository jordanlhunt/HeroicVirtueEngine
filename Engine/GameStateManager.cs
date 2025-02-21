using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    /// <summary>
    /// A Class that constains all the GameStates of the game
    /// This class also makes sure the currently active GameState updates, handlesInput, and draws itself
    /// </summary>
    public class GameStateManager : IGameLoopObject
    {
        #region Member Variables
        // The collection of all the GameStates
        Dictionary<string, GameState> gameStates;
        // A reference to the game state that is currently active
        GameState currentlyActiveGameState;
        #endregion
        #region Constructor
        public GameStateManager()
        {
            gameStates = new Dictionary<string, GameState>();
            currentlyActiveGameState = null;
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Gets the game state with the given name, if it exists.
        /// </summary>
        /// <param name="name">The name of the game state to find.</param>
        /// <returns>The GameState with that name, or null if it could not be found.</returns>
        public void AddGameState(string stateName, GameState gameState)
        {
            gameStates[stateName] = gameState;
        }
        /// <summary>
        /// Switches to a different active game state.
        /// </summary>
        /// <param name="name">The name of the game state to set as the new active one.</param>
        public void SwitchGameState(string name)
        {
            if (gameStates.ContainsKey(name))
            {
                currentlyActiveGameState = gameStates[name];
            }
        }
        /// <summary>
        /// Gets the game state with the given name, if it exists.
        /// </summary>
        /// <param name="name">The name of the game state to find.</param>
        /// <returns>The GameState with that name, or null if it could not be found.</returns>
        public GameState GetGameState(string name)
        {
            GameState gameState = null;
            if (gameStates.ContainsKey(name))
            {

                return gameStates[name];
            }
            return gameState;
        }
        /// <summary>
        /// Calls the HandleInput function for all the GameObjects in the currentlyActiveGameState
        /// </summary>
        /// <param name="inputHelper">A reference to the InputHelper to use</param>
        public void HandleInput(InputHelper inputHelper)
        {
            if (currentlyActiveGameState != null)
            {
                currentlyActiveGameState.HandleInput(inputHelper);
            }
        }

        /// <summary>
        /// Calls the Update function for all the GameObjects in the currentlyActiveGameState
        /// </summary>
        /// <param name="gameTime">An object containing information about the time that has passed in the game</param>
        public void Update(GameTime gameTime)
        {
            if (currentlyActiveGameState != null)
            {
                currentlyActiveGameState.Update(gameTime);
            }
        }
        /// <summary>
        /// Calls the Draw function for all the GameObjects in the currentlyActiveGameState
        /// </summary>
        /// <param name="gameTime">An object containing information about the time that has passed in the game</param>
        /// <param name="spriteBatch">A sprite batch object used for drawing sprites</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (currentlyActiveGameState != null)
            {
                currentlyActiveGameState.Draw(gameTime, spriteBatch);
            }
        }
        /// <summary>
        /// Calls the Reset function for all the GameObjects in the currentlyActiveGameState
        /// </summary>
        public void Reset()
        {
            if (currentlyActiveGameState != null)
            {
                currentlyActiveGameState.Reset();
            }
        }
        #endregion
    }
}