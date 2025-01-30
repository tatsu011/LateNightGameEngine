using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateNightGameEngine.Source
{
    internal class LevelManager
    {
        public static List<Level> Levels = new List<Level>();
        public static Level currentLevel = null;

        public static void ChangeLevel(string levelName)
        {
            foreach (Level level in Levels)
            {
                if (level.Name == levelName)
                {
                    if (currentLevel != null)
                    {
                        currentLevel.OnDestroy();
                    }
                    currentLevel = level;
                    InitLevel();
                    return;
                }
            }

            Log.Error($"[LevelManager]Level {levelName} does not exist in the current context.");

        }


        public static void InitLevel()
        {
            Log.Info($"[LevelManager] Loading Level: {currentLevel.Name}");
            if (currentLevel.Init)
            {
                currentLevel.OnDestroy(); //clean up the level if it isn't already.
            }

            currentLevel.OnLoad();
        }

        public static void UpdateLevel()
        {
            if (currentLevel == null) { return; }
            currentLevel.OnUpdate();
        }

    }
}
