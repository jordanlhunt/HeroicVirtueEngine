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
        /// Marks a level as solved, then unlocks the next level if possible and saves the player's progess.
        /// </summary>
        /// <param name="levelIndex">The index of the level to mark as solved</param>
        public static void MarkLevelAsSolved(int levelIndex)
        {
            // mark this level as solved
            SetLevelStatus(levelIndex, LevelStatus.Solved);
            // if there is a next level mark it as unlocked
            if (levelIndex < NumberOfLevels && GetLevelStatus(levelIndex + 1) == LevelStatus.Locked)
            {
                SetLevelStatus(levelIndex + 1, LevelStatus.Unlocked);
            }
            // Store the new level status
            SaveProgress();
        }

        /// <summary>
        /// Send the player to the next level in the game if possible, if not it sends them back to the level selection screen
        /// </summary>
        /// <param name="levelIndex">The index of the current level</param>
        public static void GoToNextLevel(int levelIndex)
        {
            // if this is the last level, go back to the level select menu
            if (levelIndex == NumberOfLevels)
            {
                GameStateManager.SwitchGameState(STATENAME_LEVELSELECT);
            }
        }
        public static IPlayingState GetPlayingState()
        {
            return ((IPlayingState)GameStateManager.GetGameState(STATENAME_PLAYING));
        }
        #endregion
        #region Private Methods
        /// <summary>
        /// Saves the player's progress to a file
        /// </summary>
        static void SaveProgress()
        {
            // Write to a "level_status" file; add a LevelStatus for each line
            StreamWriter streamWriter = new StreamWriter("Content/Levels/levels_status.txt");
            foreach (LevelStatus status in progressList)
            {
                if (status == LevelStatus.Locked)
                {
                    streamWriter.WriteLine("locked");
                }
                else if (status == LevelStatus.Unlocked)
                {
                    streamWriter.WriteLine("unlocked");
                }
                else
                {
                    streamWriter.WriteLine("solved");
                }
            }
            streamWriter.Close();
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
        #endregion
    }
}
