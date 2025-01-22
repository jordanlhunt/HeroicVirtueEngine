namespace Engine
{
    /// <summary>
    /// An abstract class that represents a game with multiple levels and their respective statuses
    /// </summary>
    public abstract class ExtendedGameWithLevels : ExtendedGame
    {
        #region Member Variables
        public static string STATENAME_TITLE = "title";
        public static string STATENAME_HELP = "help";
        public static string STATENAME_LEVELSELECT = "levelselect";
        public static string STATENAME_PLAYING = "playing";
        const string LEVEL_STATUS_LOCKED = "locked";
        const string LEVEL_STATUS_UNLOCKED = "unlocked";
        const string LEVEL_STATUS_SOLVED = "solved";

        static List<LevelStatus> progressList;
        #endregion

        #region Properties
        /// <summary>
        /// The total number of levels in the game
        /// </summary>
        public static int NumberOfLevels
        {
            get
            {
                return progressList.Count;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Loads the player's level progress from a text file.
        /// </summary>
        protected void LoadProgress()
        {

            // prepare a list of LevelStatus values
            progressList = new List<LevelStatus>();
            // Read the "levels_status" file; add a LevelStatus object for each line
            StreamReader streamReader = new StreamReader("Content/Levels/levels_status.txt");
            string currentLine = streamReader.ReadLine();
            while (currentLine != null)
            {
                if (currentLine == LEVEL_STATUS_LOCKED)
                {
                    progressList.Add(LevelStatus.Locked);
                }
                else if (currentLine == LEVEL_STATUS_UNLOCKED)
                {
                    progressList.Add(LevelStatus.Unlocked);
                }
                else if (currentLine == LEVEL_STATUS_SOLVED)
                {
                    progressList.Add(LevelStatus.Solved);
                }
                currentLine = streamReader.ReadLine();
            }
            streamReader.Close();
        }
        #endregion
        /// <summary>
        /// Gets the <see cref="LevelStatus"/> of the level with the given index.
        /// </summary>
        /// <param name="levelIndex">The index of the level to check,<param>
        /// <returns>The <see cref="LevelStatus"/> of the requested level.</returns>
        public static LevelStatus GetLevelStatus(int levelIndex)
        {
            return progressList[levelIndex - 1];
        }
        /// <summary>
        /// Sets the <see cref="LevelStatus"/> of the given level to the given value.
        /// </summary>
        /// <param name="levelIndex">The index of the level to change.<param>
        /// <param name="status">The new desired status of the level.</param>
        static void SetLevelStatus(int levelIndex, LevelStatus status)
        {
            progressList[levelIndex - 1] = status;
        }
    }
}
