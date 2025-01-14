using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    /// <summary>
    /// A game object that shows text
    /// </summary>
    public class TextGameObject : GameObject
    {
        #region Member Variables
        /// <summary>
        /// The layerDepth (between 0 and 1) at which the text is drawn. 0 is behind everything, 1 is on top of everything
        /// </summary>
        protected float layerDepth;
        /// <summary>
        /// The horizontal alignment of the text.
        /// </summary>
        public Alignment alignment;
        /// <summary>
        /// The font to be used to display the text.
        /// </summary>
        public SpriteFont font;

        /// <summary>
        /// An enum that describes the horizontal position of the text
        /// </summary>
        public enum Alignment
        {
            Left, Right, Center
        }

        #endregion
        #region Properties
        /// <summary>
        /// The color of the text
        /// </summary>
        public Color Color
        {
            get; set;
        }
        /// <summary>
        /// The value of the text
        /// </summary>
        public String Text
        {
            get; set;
        }

        /// <summary>
        /// Gets the x-coordinate to use as an origin for drawing the text. The value is dependent on the horizontal alignment and the width of hte text
        /// </summary>
        private float OriginX
        {
            get
            {
                float xCoordinate = 0;
                if (alignment == Alignment.Left)
                {
                    xCoordinate = 0;
                }
                if (alignment == Alignment.Right)
                {
                    xCoordinate = font.MeasureString(Text).X;
                }
                if (alignment == Alignment.Center)
                {
                    xCoordinate = font.MeasureString(Text).X / 2.0f;
                }
                return xCoordinate;
            }
        }
        #endregion
        #region Constructor
        /// <summary>
        /// Creates a new TextGameObjectg with the given details
        /// </summary>
        /// <param name="fontName">The name of the font to use.</param>
        /// <param name="layerDepth">The layerDepth of the text to be drawn</param>
        /// <param name="color">The color to draw the text</param>
        /// <param name="alignment">The alignment of the text</param>
        public TextGameObject(string fontName, float layerDepth, Color color, Alignment alignment = Alignment.Left)
        {
            font = ExtendedGame.AssetManager.LoadFont(fontName);
            Color = color;
            this.layerDepth = layerDepth;
            this.alignment = alignment;
            Text = "[DEFAULT TEXT]";
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Draws this TextGameObject on the screen.
        /// </summary>
        /// <param name="gameTime">An object containing information about the time that has passed in the game</param>
        /// <param name="spriteBatch">A sprite batch object used for drawing sprites</param>
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (IsVisible == false)
            {
                return;
            }
            // Calculate the origin
            Vector2 origin = new Vector2(OriginX, 0);
            // Draw the text
            spriteBatch.DrawString(font, Text, GlobalPosition, Color, 0f, origin, 1, SpriteEffects.None, layerDepth);
        }
        #endregion
    }
}
