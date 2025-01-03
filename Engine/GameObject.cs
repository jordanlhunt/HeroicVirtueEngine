

using Microsoft.Xna.Framework;

namespace Engine
{
    internal class GameObject : IGameLoopObject
    {
        #region Memeber Variables
        protected Vector2 localPosition;
        protected Vector2 velocity;
        #endregion
        #region Properties
        public Vector2 LocalPosition
        {
            get
            {
                return LocalPosition;
            }
            set
            {
                localPosition = value;
            }
        }
        #endregion
    }
}
