using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    /// <summary>
    /// A class that can represent a game object with a sprite
    /// </summary>
    public class SpriteGameObject : GameObject
    {
        #region Member Variables 
        /// <summary>
        /// The sprite that this object can draw to the screen
        /// </summary>
        protected SpriteSheet sprite;
        /// <summary>
        /// The order at which this object should be drawn. A value from 0 to 1 larger values are drawn on top
        /// </summary>
        protected float drawOrder;
        #endregion
        #region Properties
        /// <summary>
        /// The sheet index of the attached sprite sheet
        /// </summary>
        public int SheetIndex
        {
            get
            {
                return sprite.SheetIndex;
            }
            set
            {
                sprite.SheetIndex = value;
            }
        }
        /// <summary>
        /// The origin ('offset') to use when drawing the sprite on the screen.
        /// </summary>
        public Vector2 Origin
        {
            get; set;
        }
        /// <summary>
        ///  Gets the Width of this object in the game world according to its sprite
        /// </summary>
        public int Width
        {
            get
            {
                return sprite.Width;
            }
        }
        /// <summary>
        /// Gets the Height of this object in the game world according to its sprite
        /// </summary>
        public int Height
        {
            get
            {
                return sprite.Height;
            }
        }
        public Rectangle BoundingBox
        {
            get
            {
                // Get the sprite's bounding box
                Rectangle spriteBounds = sprite.Bounds;
                spriteBounds.Offset(GlobalPosition - Origin);
                return spriteBounds;
            }
        }

        #endregion
        #region Constructor
        /// <summary>
        /// Creates a new SpriteGameObject with a given sprite name
        /// </summary>
        /// <param name="spriteName">The name of the sprite to load</param>
        /// <param name="drawOrder">The order in which the object should be drawn.</param>
        /// <param name="sheetIndex">The sheet index of the sprite to use</param>
        public SpriteGameObject(string spriteName, float drawOrder, int sheetIndex = 0)
        {
            this.drawOrder = drawOrder;
            if (spriteName != null)
            {
                sprite = new SpriteSheet(spriteName, drawOrder, sheetIndex);
            }
            Origin = Vector2.Zero;
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Draws this SpriteGameObject on the screen, using its global position and origin. Will only be drawn if IsVisable is true
        /// </summary>
        /// <param name="gameTime">An object containing information about the time that has passed in the game</param>
        /// <param name="spriteBatch">A sprite batch object used for drawing Sprites</param>
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (IsVisible == false)
            {
                return;
            }
            // Draw the sprite at its GLOBAL Position in the game world
            if (sprite != null)
            {
                sprite.Draw(spriteBatch, GlobalPosition, Origin);
            }
        }
        /// <summary>
        ///  Updates this object's origin so that it lies in the cent of the object
        /// </summary>
        public void SetOriginToCenter()
        {
            Origin = sprite.Center;
        }
        /// <summary>
        /// Checks and returns if this SpriteGameObject has at least one non-transparent pixel inside the given rectangle
        /// </summary>
        /// <param name="other">A rectangle in the game world</param>
        /// <returns>true if this object overlaps with a the given rectangle and that intersection constains at least one non-transparent pixel. false otherwise</returns>
        public bool HasPixelPreciseCollision(Rectangle other)
        {
            bool hasPixelPreciseCollision = false;

            Rectangle intersection = CollisionDetection.CalculateIntersection(BoundingBox, other);

            // If at least one pixel in this part is not transparent then there is a collision
            for (int x = 0; x < intersection.Width; x++)
            {
                for (int y = 0; y < intersection.Height; y++)
                {
                    int thisX = intersection.X - (int)(GlobalPosition.X - Origin.X) + x;
                    int thisY = intersection.Y - (int)(GlobalPosition.Y - Origin.Y) + y;
                    if (sprite.IsPixelTransparent(thisX, thisY) == false)
                    {
                        hasPixelPreciseCollision = true;
                    }
                }
            }
            return hasPixelPreciseCollision;
        }
        public bool HasPixelPreciseCollision(SpriteGameObject other)
        {
            // calculate the intersection between the two bounding boxes
            Rectangle intersection = CollisionDetection.CalculateIntersection(BoundingBox, other.BoundingBox);

            for (int x = 0; x < intersection.Width; x++)
            {
                for (int y = 0; y < intersection.Height; y++)
                {
                    // get the correct pixel coordinates of both sprites
                    int thisX = intersection.X - (int)(GlobalPosition.X - Origin.X) + x;
                    int thisY = intersection.Y - (int)(GlobalPosition.Y - Origin.Y) + y;
                    int otherX = intersection.X - (int)(other.GlobalPosition.X - other.Origin.X) + x;
                    int otherY = intersection.Y - (int)(other.GlobalPosition.Y - other.Origin.Y) + y;

                    // if both pixels are not transparent, then there is a collision
                    if (!sprite.IsPixelTransparent(thisX, thisY) && !other.sprite.IsPixelTransparent(otherX, otherY))
                        return true;
                }
            }
            // otherwise, there is no collision
            return false;
        }
        #endregion
    }
}
