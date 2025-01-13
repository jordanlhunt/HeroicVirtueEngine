using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public class SpriteSheet
    {
        #region Constructor
        public SpriteSheet(string spriteName, float drawOrder, int sheetIndex)
        {
            SheetIndex = sheetIndex;
        }
        #endregion
        #region Properties

        public int SheetIndex
        {
            get;
            internal set;
        }
        public int Height
        {
            get;
            internal set;
        }
        public int Width
        {
            get;
            internal set;
        }
        public Rectangle Bounds
        {
            get;
            internal set;
        }
        public Vector2 Center
        {
            get;
            internal set;
        }
        #endregion
        #region Public Methods
        internal void Draw(SpriteBatch spriteBatch, Vector2 globalPosition, Vector2 origin)
        {
            throw new NotImplementedException();
        }

        internal bool IsPixelTransparent(object intersectionX, object intersectionY)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}