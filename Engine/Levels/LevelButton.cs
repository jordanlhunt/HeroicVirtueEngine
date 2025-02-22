using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.UI
{
    /// <summary>
    /// A class that can represent a single button on a level selection screen
    /// </summary>
    public class LevelButton : Button
    {
        #region Member Variables
        LevelStatus levelStatus;
        protected TextGameObject buttonLabel;
        const float DEFAULT_LAYER_DEPTH = 0.9f;
        #endregion
        #region Properties
        /// <summary>
        /// The index of the level this button represents
        /// </summary>
        public int LevelIndex
        {
            get;
            private set;
        }
        public LevelStatus Status
        {
            get
            {
                return levelStatus;
            }
            set
            {
                levelStatus = value;
                sprite = new SpriteSheet(getSpriteNameForLevelStatus(levelStatus), layerDepth);
                sprite.SheetIndex = (LevelIndex - 1) % sprite.NumberOfSheetElements;
            }
        }
        #endregion
        #region Constructor
        /// <summary>
        /// Creates a new <see cref="LevelButton"/> with the given level index and level status
        /// </summary>
        /// <param name="levelIndex">The index of the level to which this button corresponds.</param>
        /// <param name="startStatus">The initial status of the associated level</param>
        public LevelButton(int levelIndex, LevelStatus startStatus) : base(null, DEFAULT_LAYER_DEPTH)
        {
            LevelIndex = levelIndex;
            Status = startStatus;
        }
        #endregion
        #region Public Methods

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
            if (buttonLabel != null)
            {
                buttonLabel.Draw(gameTime, spriteBatch);
            }
        }
        #endregion

        #region Private Methods
        protected virtual string getSpriteNameForLevelStatus(LevelStatus status)
        {
            string spriteName = "";
            if (status == LevelStatus.Locked)
            {
                spriteName = "Sprites/UI/spr_level_locked";
            }
            else if (status == LevelStatus.Unlocked)
            {
                spriteName = "Sprites/UI/spr_level_unsolved";
            }
            else
            {
                spriteName = "Sprites/UI/spr_level_solved";
            }
            return spriteName;
        }
        #endregion
    }
}
