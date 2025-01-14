﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public class SpriteSheet
    {
        #region Member Variables
        Texture2D sprite;
        Rectangle spriteRectangle;
        int sheetIndex;
        int sheetColumns;
        int sheetRows;
        float layerDepth;
        bool[,] pixelTranparency;
        #endregion
        #region Constructor
        public SpriteSheet(string spriteName, float layerDepth, int sheetIndex)
        {
            SheetIndex = sheetIndex;
        }
        #endregion
        #region Properties
        public bool IsMirrored
        {
            get; set;
        }
        /// <summary>
        /// Gets or sets the sprite index within this sprite sheet to use. The current sprite
        /// If you set a new index, the object will recalculate which part of the sprite should be drawn
        /// </summary>
        public int SheetIndex
        {
            get
            {
                return sheetIndex;
            }
            set
            {
                if (value < NumberOfSheetElements && value >= 0)
                {
                    sheetIndex = value;
                    // recalulate the part of the sprite to draw
                    int columnIndex = sheetIndex % sheetColumns;
                    int rowIndex = sheetIndex / sheetColumns;
                    spriteRectangle = new Rectangle(columnIndex * Width, rowIndex * Height, Width, Height);
                }
            }
        }
        /// <summary>
        /// Get the height of a single sprite in the sprite sheet
        /// </summary>
        public int Height
        {
            get
            {
                return sprite.Height / sheetRows;
            }
        }
        /// <summary>
        /// Get the width of a single spirte in the sprite sheet
        /// </summary>
        public int Width
        {
            get
            {
                return sprite.Width / sheetColumns;
            }
        }
        /// <summary>
        /// Gets a rectangle that represents the bounds of a single sprite in this sprite sheet
        /// </summary>
        public Rectangle Bounds
        {
            get
            {
                return new Rectangle(0, 0, Width, Height);
            }
        }
        /// <summary>
        /// Gets a vector that represents the center of the a single sprite in the sprite sheet
        /// </summary>
        public Vector2 Center
        {
            get
            {
                return new Vector2(Width, Height) / 2;
            }
        }
        /// <summary>
        /// Get the total number of elements in this sprite sheet
        /// </summary>
        public int NumberOfSheetElements
        {
            get
            {
                return (sheetColumns * sheetRows);
            }
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Draws the sprite (or the apporopriate part of it) at the desired position
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch object used for drawing sprites.</param>
        /// <param name="globalPosition">A position in the game world.</param>
        /// <param name="origin">An origin that should be subtracted from the drawing position</param>
        internal void Draw(SpriteBatch spriteBatch, Vector2 globalPosition, Vector2 origin)
        {
            SpriteEffects spriteEffects = SpriteEffects.None;
            if (IsMirrored == true)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
            spriteBatch.Draw(sprite, globalPosition, spriteRectangle, Color.White, 0.0f, origin, 1.0f, spriteEffects, layerDepth);
        }

        /// <summary>
        /// Returns wheter or not the pixel at a given coordinate is transparent.
        /// </summary>
        /// <param name="x">The x-coordinate of the pixel.</param>
        /// <param name="y">The y-coordinate of the pixel.</param>
        /// <returns>true if the given pixel is fully transparent;</returns>
        internal bool IsPixelTransparent(int x, int y)
        {
            int column = sheetIndex % sheetColumns;
            int row = sheetIndex / sheetColumns % sheetRows;
            return pixelTranparency[column * Width + x, row * Height + y];
        }
        #endregion
    }
}