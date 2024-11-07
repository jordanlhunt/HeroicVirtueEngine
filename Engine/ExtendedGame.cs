﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public abstract class ExtendedGame : Game
    {
        #region Constants
        int WINDOW_SIZE_X = 1024;
        int WINDOW_SIZE_Y = 768;
        int GAMEWORLD_SIZE_X = 1024;
        int GAMEWORLD_SIZE_Y = 768;
        #endregion
        #region Member Variables
        // Standard Monogame objects for graphics and sprites
        protected GraphicsDeviceManager graphics;
        protected SpriteBatch spriteBatch;
        // Object for handling keyboard and mouse input
        protected InputHelper inputHelper;
        /// <summary>
        /// The width and hieght of the game world in game units
        /// </summary>
        protected Point gameWorldSize;
        /// <summary>
        /// The width and height of the window, in pixels
        /// </summary>
        protected Point windowSize;
        /// <summary>
        /// A matrix used for scaling the game world so it fits inside the window.
        /// </summary>
        Matrix spriteScaleMatrix;
        #endregion
        #region Properties

        /// <summary>
        /// An object for generating Random numbers throughout the game
        /// </summary>
        public static Random? Random
        {
            get;
            private set;
        }
        /// <summary>
        /// An object for loding assets throughout the game
        /// </summary>
        public static AssetManager AssetManager
        {
            get;
            private set;
        }
        /// <summary>
        /// The object that manages all the game states
        /// </summary>
        public static GameStateManager GameStateManager
        {
            get;
            private set;
        }
        public static string ContentRootDirectory
        {
            get
            {
                return "Content";
            }
        }
        /// <summary>
        /// Gets or Sets whether the game is running in full-screen mode
        /// </summary>
        protected bool IsFullScreen
        {
            get
            {
                return graphics.IsFullScreen;
            }
            set
            {
                ApplyResolutionSettings(value);
            }
        }
        #endregion
        #region Constructor
        /// <summary>
        /// Creates a new ExtendedGameObject
        /// </summary>
        protected ExtendedGame()
        {
            // Monogame preparations
            Content.RootDirectory = ContentRootDirectory;
            graphics = new GraphicsDeviceManager(this);
            inputHelper = new InputHelper(this);
            Random = new Random();
            // Configure default window
            windowSize = new Point(WINDOW_SIZE_X, WINDOW_SIZE_Y);
            gameWorldSize = new Point(GAMEWORLD_SIZE_X, GAMEWORLD_SIZE_Y);
        }
        #endregion
        #region Public Methods
        /// <summary> 
        /// Does the initialization tasks that involve assets, and then prepares the game world
        /// </summary>
        protected override void LoadContent()
        {
            // store a static reference to the AssetManager
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // prepare an empty GameStateManager
            GameStateManager = new GameStateManager();
            // Set the game size to windowed by default
            IsFullScreen = false;
        }
        /// <summary>
        /// Updates all the objects in the game world, by first calling HandleInput then GameStateManager update
        /// </summary>
        /// <param name="gameTime">An object containing information about the time that has passed.</param>
        protected override void Update(GameTime gameTime)
        {
            HandleInput();
            GameStateManager.Update(gameTime);
        }
        /// <summary>
        /// Performs basic input handling and then calls HandleInput for the entire game world
        /// </summary>
        protected void HandleInput()
        {
            inputHelper.Update();
            // Quit the game when the player hits ESC
            if (inputHelper.KeyPressed(Keys.Escape))
            {
                Exit();
            }
            // Toggle full-screen on player hits F5
            if (inputHelper.KeyPressed(Keys.F5))
            {
                IsFullScreen = !IsFullScreen;
            }
            GameStateManager.HandleInput(inputHelper);
        }
        /// <summary>
        /// Draws the game world
        /// </summary>
        /// <param name="gameTime">An object containing information about the time has passed</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            // start drawing sprites, applying the scaling matrix
            spriteBatch.Begin(SpriteSortMode.FrontToBack, null, null, null, null, null, spriteScaleMatrix);
            // Draw the game world itself
            GameStateManager.Draw(gameTime, spriteBatch);
        }
        /// <summary>
        /// Scales the window to the desired size, and calculates how the game world should be scaled to fit inside that window
        /// </summary>
        void ApplyResolutionSettings(bool isFullScreen)
        {
            // Make the game full-screen or not
            graphics.IsFullScreen = isFullScreen;
            // Get the size of the screen to use: either the window or the full-screen size
            Point screenSize;
            if (isFullScreen)
            {
                screenSize = new Point(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height);
            }
            else
            {
                screenSize = windowSize;
            }
            // Scale the window to the desired size
            graphics.PreferredBackBufferWidth = screenSize.X;
            graphics.PreferredBackBufferHeight = screenSize.Y;
            graphics.ApplyChanges();
            // Calculate and set the viewport to use
            GraphicsDevice.Viewport = CalculateViewport(screenSize);
            // Calculate how the graphics should be scaled, the game world fits inside the window
            spriteScaleMatrix = Matrix.CreateScale((float)GraphicsDevice.Viewport.Width / gameWorldSize.X, (float)GraphicsDevice.Viewport.Height / gameWorldSize.Y, 1);
        }
        #endregion
    }
}