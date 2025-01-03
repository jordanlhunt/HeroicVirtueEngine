using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    /// <summary>
    /// A non-visual game object that has a list of game objects as its children
    /// </summary>
    internal class GameObjectList : GameObject
    {
        #region Member Variables
        /// <summary>
        /// The child objects of this game object
        /// </summary>
        List<GameObject> children;
        #endregion
        #region Consturctor
        /// <summary>
        /// Creates a new GameObjectList with an empty list of children
        /// </summary>
        public GameObjectList()
        {
            children = new List<GameObject>();
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Sets this GameObjectList as the parent of the object. Adds a GameObject object to this GameObjectList
        /// </summary>
        /// <param name="gameObject">The Game object to add</param>
        public void AddChild(GameObject gameObject)
        {
            gameObject.Parent = this;
            children.Add(gameObject);
        }
        /// <summary>
        /// Peforms input handling for all the children in the list
        /// </summary>
        /// <param name="inputHelper"> An object required for handling player input
        /// </param>
        public override void HandleInput(InputHelper inputHelper)
        {
            for (int i = children.Count - 1; i >= 0; i--)
            {
                children[i].HandleInput(inputHelper);
            }
        }
        /// <summary>
        /// Peforms the draw methods for all the game objects in children list
        /// </summary>
        /// <param name="gameTime">An object containing information about the time that has passed</param>
        /// <param name="spriteBatch">A sprite batch object used for drawing sprites</param>
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (IsVisible == false)
            {
                return;
            }
            foreach (GameObject gameObject in children)
            {
                gameObject.Draw(gameTime, spriteBatch);
            }
        }
        /// <summary>
        /// Performs the Reset method for all game objects in this GameObjectList.
        /// </summary>
        public override void Reset()
        {
            foreach (GameObject gameObject in children)
                gameObject.Reset();
        }
        #endregion
    }
}
