using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public class InputHelper
    {
        #region Member Variables
        // Current and Previous mouse State
        MouseState currentMouseState;
        MouseState previousMouseState;
        // Current and Previous keyboard state
        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;
        // A reference to the game
        ExtendedGame game;
        #endregion
        #region Properties
        /// <summary>
        /// Gets the current position of the mouse in screen coordinates
        /// </summary>
        public Vector2 MousePositionScreen
        {
            get
            {
                return new Vector2(currentMouseState.X, currentMouseState.Y);
            }
        }
        /// <summary>
        /// Gets the current position of the mouse in world coordinates
        /// </summary>
        public Vector2 MousePositionWorld
        {
            get
            {
                return game.ScreenToWorld(MousePositionScreen);
            }
        }

        #endregion

        #region Consturctor
        public InputHelper(ExtendedGame extendedGame)
        {
            this.game = extendedGame;
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Updates the inputHelper Object for one frame of the game loop. 
        /// This method retrieves the current state of the mouse and keyboard, and stores the previous states
        /// </summary>
        public void Update()
        {
            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();
        }
        /// <summary>
        /// Returns if the player has started pressing the left mouse button in the last frame of the game loop
        /// </summary>
        /// <returns>true if the left mouse button is pressed and was not yet pressed in the previous frame</returns>
        public bool IsMouseLeftButtonPressed()
        {
            return (currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released);
        }
        /// <summary>
        /// Returns whether the player is currently holding down the left mouse button
        /// </summary>
        /// <returns>true if the left mouse button is currently being held down</returns>
        public bool IsMouseLeftButtonDown()
        {
            return (currentMouseState.LeftButton == ButtonState.Pressed);
        }
        /// <summary>
        /// Checks and returns if the player has started pressing a keyboard key in the last frame of the game loop
        /// </summary>
        /// <param name="someKey">The keyboard key to check</param>
        /// <returns>true if the key is now pressed and was not yet pressed in the previous frame</returns>
        public bool IsKeyPressed(Keys someKey)
        {
            return (currentKeyboardState.IsKeyDown(someKey) && previousKeyboardState.IsKeyUp(someKey));
        }
        /// <summary>
        /// Checks and returns if the player has stopped pressing a keyboard key in the last frame of the game loop
        /// </summary>
        /// <param name="someKey">The keyboard key to check</param>
        /// <returns>true if the key is no longer pressed but was pressed in the previous frame</returns>
        public bool IsKeyReleased(Keys someKey)
        {
            return (currentKeyboardState.IsKeyUp(someKey) && previousKeyboardState.IsKeyDown(someKey));
        }
        /// <summary>
        /// Checks and returns whether the player is current holding a key down
        /// </summary>
        /// <param name="someKey">The keyboard key to check</param>
        /// <returns>true if the given key is currently being held</returns>
        public bool IsKeyDown(Keys someKey)
        {
            return currentKeyboardState.IsKeyDown(someKey);
        }
        #endregion
    }
}