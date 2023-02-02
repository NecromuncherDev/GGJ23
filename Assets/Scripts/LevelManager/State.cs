using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ.Core
{

    public static class State
    {
        public static int CurrentLayer = 0;
        public static LevelIndex CurrentLevelIndex = LevelIndex.Invalid;
        public static HashSet<LevelIndex> VisitedLevels = new HashSet<LevelIndex>();

        public static void VisitLevel(LevelIndex levelIndex)
        {
            CurrentLevelIndex = levelIndex;
            if (VisitedLevels.Contains(levelIndex))
                return;

            VisitedLevels.Add(levelIndex);
        }

        public static void WinLevel()
        {
            CurrentLayer = CurrentLevelIndex.LayerIndex + 1;
        }
    }

}