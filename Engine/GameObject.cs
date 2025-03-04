

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public class GameObject : IGameLoopObject
    {
        #region Member Variables
        protected Vector2 localPosition;
        /// <summary>
        /// The current velocity of this game object in units per second
        /// </summary>
        protected Vector2 velocity;
        #endregion
        #region Properties
        /// <summary>
        /// The position of the game object, relative to its parent in the hierarchy 
        /// </summary>
        public Vector2 LocalPosition
        {
            get
            {
                return localPosition;
            }
            set
            {
                localPosition = value;
            }
        }

        public bool IsVisible
        {
            get;
            set;
        }
        /// <summary>
        /// The parent of this object in the game object hierarchy
        /// If the object has a parent, its position depends on its parents position 
        /// </summary>
        public GameObject Parent
        {
            get;
            set;
        }
        /// <summary>
        /// Gets this object's global position in the game world, by adding its local position to the global position of its parent.
        /// </summary>
        public Vector2 GlobalPosition
        {
            get
            {
                if (Parent == null)
                {
                    return LocalPosition;
                }
                else
                {
                    return LocalPosition + Parent.GlobalPosition;
                }
            }
        }
        #endregion
        #region Constructor
        /// <summary>
        /// Creates a new GameObject.
        /// </summary>
        public GameObject()
        {
            LocalPosition = Vector2.Zero;
            velocity = Vector2.Zero;
            IsVisible = true;
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Performs input handling for this GameObject
        /// </summary>
        /// <param name="inputHelper"> An object with information about the player input
        /// </param>
        public virtual void HandleInput(InputHelper inputHelper)
        {
        }
        /// <summary>
        /// Updates this GameObject by one frame
        /// By default this method updates the object's position according to it's velocity
        /// It can be overridden because it's virtual
        /// </summary>
        /// <param name="gameTime">An object containing information about hte the time that has passed 
        /// </param>
        public virtual void Update(GameTime gameTime)
        {
            LocalPosition += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        /// <summary>
        /// Draws this GameObject. By default, nothing happens but can be overriden
        /// </summary>
        /// <param name="gameTime">An object containing information about hte time that has passed</param>
        /// <param name="spriteBatch">The spriteBatch to use</param>
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
        }
        /// <summary>
        /// Resets this game object to an inital state.
        /// </summary>
        public virtual void Reset()
        {
            velocity = Vector2.Zero;
        }
        #endregion
    }
}
