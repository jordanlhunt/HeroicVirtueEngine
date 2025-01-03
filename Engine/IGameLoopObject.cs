using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    /// <summary>
    /// An interface used for objects that can do "game loop"-releated tasks
    /// * Handling Input
    /// * Updating
    /// * Drawing
    /// * Resetting
    /// </summary>
    internal class IGameLoopObject
    {
        void HandleInput(InputHelper inputHelper);
        void Update(GameTime gametime);
        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        void Reset();
    }
}
