namespace Engine.UI
{
    public class Switch : Button
    {
        #region Member Variables
        protected bool isSelected;
        #endregion
        #region Properties

        /// <summary>
        /// Whether or not this switch is currently selected.
        /// If you change this value, the switch will receive a different sprite sheet index.
        /// </summary>
        public bool Selected
        {
            get
            {
                return Selected;
            }
            set
            {
                isSelected = value;
                if (isSelected == true)
                {
                    SheetIndex = 1;
                }
                else
                {
                    SheetIndex = 0;
                }
            }
        }
        #endregion
        #region Constructor
        /// <summary>
        /// Creates a new <see cref="Switch"/> with the given sprite name and depth.
        /// </summary>
        /// <param name="assetName">The name of the sprite to use.</param>
        /// <param name="layerDepth">The depth at which the object should be drawn.</param>
        public Switch(string assetName, float layerDepth) : base(assetName, layerDepth)
        {
            Selected = false;
        }
        #region Public Methods

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (Pressed)
                Selected = !Selected;
        }

        public override void Reset()
        {
            base.Reset();
            Selected = false;
        }
        #endregion
    }
}
