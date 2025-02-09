using Microsoft.Xna.Framework;

namespace Engine.UI
{
    internal class Slider : GameObjectList
    {
        #region Member Variables
        const float DEFAULT_LAYER_DEPTH = 0.9f;
        // The sprites for the background and foreground of the slide
        SpriteGameObject background;
        SpriteGameObject foreground;
        // The minium and maximum value for the slider
        float minimumValue;
        float maximumValue;
        // current value the slider is storing
        float currentValue;
        // the value the slider had in the previous frame
        float previousValue;
        float padding;
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the current number value that's stored in this slider.
        /// When you set this value the forground image will move to the correct position
        /// </summary>
        public float CurrentValue
        {
            get
            {
                return currentValue;
            }
            set
            {
                currentValue = MathHelper.Clamp(value, minimumValue, maximumValue);
                // Calculate the new position of the foreground image
                float fraction = (currentValue - minimumValue) / Range;
                float newXPosition = MinimumLocalX + fraction * AvailableWidth;
            }
        }
        /// <summary>
        /// Returns whether the slider's value has changed in the last frame of the game loop
        /// </summary>
        public bool ValueChanged
        {
            get
            {
                return currentValue != previousValue;
            }
        }
        /// <summary>
        /// The difference between the minimum and maximum value that the slider can store
        /// </summary>
        float Range
        {
            get
            {
                return maximumValue - minimumValue;
            }
        }
        // The smallest X coordinate that the front image may have
        float MinimumLocalX
        {
            get
            {
                return padding + foreground.Width / 2;
            }
        }
        // The largest X coordinate that the front image may have
        float MaximumLocalX
        {
            get
            {
                return background.Width - padding - foreground.Width / 2;
            }
        }
        // The total pixel width that is available for the front image
        float AvailableWidth
        {
            get
            {
                return MaximumLocalX - MinimumLocalX;
            }
        }
        #endregion
        #region Constructor 
        public Slider(string backgroundSprite, string foregroundSprite, float minValue, float maxValue, float padding)
        {
            // add the background image
            background = new SpriteGameObject(backgroundSprite, DEFAULT_LAYER_DEPTH);
            AddChild(background);
            // add the foreground image
            foreground = new SpriteGameObject(foregroundSprite, DEFAULT_LAYER_DEPTH + .05f);
            foreground.Origin = new Vector2(foreground.Width / 2, 0);
            AddChild(foreground);
            // store the other values
            minimumValue = minValue;
            maximumValue = maxValue;
            this.padding = padding;
            // By default start the minimum value
            previousValue = minimumValue;
            currentValue = previousValue;
        }
        #endregion
        #region Public Methods
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (!IsVisible)
            {
                return;
            }
            Vector2 currentMousePosition = inputHelper.MousePositionWorld;
            previousValue = currentValue;
            if (inputHelper.IsMouseLeftButtonDown() && background.BoundingBox.Contains(currentMousePosition))
            {
                // translate the mouse position to a number between 0 and 1
                float correctedX = currentMousePosition.X - GlobalPosition.X - MinimumLocalX;
                float newFraction = correctedX / AvailableWidth;
                // Convert that to the current slider value
                CurrentValue = newFraction * Range + minimumValue;
            }
        }
        #endregion
    }
}
