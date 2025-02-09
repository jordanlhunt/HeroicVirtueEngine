namespace Engine.UI
{
    /// <summary>
    /// A class that can represent a UI button in the game
    /// </summary>
    internal class Button : SpriteGameObject
    {
        #region Properties
        /// <summary>
        /// A boolean check to whether the button is pressed/clicked in the current frame
        /// </summary>
        public bool Pressed
        {
            get;
            protected set;
        }
        #endregion
        #region Constructor
        /// <summary>
        /// Creates a new <see cref="Button"/> with the give sprite name and dpeth.
        /// </summary>
        /// <param name="assetName">The name of the sprite to use</param>
        /// <param name="layerDepth">The depth at which the button should be drawn.</param>
        public Button(string assetName, float layerDepth) : base(assetName, layerDepth)
        {
            Pressed = false;
        }
        #endregion

        #region Public Methods
        public override void HandleInput(InputHelper inputHelper)
        {
            bool isMouseOverButton = BoundingBox.Contains(inputHelper.MousePositionWorld);
            bool isMousePressed = inputHelper.IsMouseLeftButtonPressed();
            Pressed = IsVisible && isMouseOverButton && isMousePressed;
        }
        public override void Reset()
        {
            base.Reset();
            Pressed = false;
        }
        #endregion
    }
}
