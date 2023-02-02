using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GGJ.Core
{
    public enum GameState
    {
        Playing,
        Win,
        Lose
    }

    public static class State
    {
        public static int CurrentLayer = 0;
        public static LevelIndex CurrentLevelIndex = LevelIndex.Invalid;
        public static HashSet<LevelIndex> VisitedLevels = new HashSet<LevelIndex>();

        public static GameState CurrentGameState = GameState.Playing;

        public static void MarkVisited(LevelIndex levelIndex)
        {
            CurrentLevelIndex = levelIndex;
            if (VisitedLevels.Contains(levelIndex))
                return;

            VisitedLevels.Add(levelIndex);
        }

        public static void WinLevel()
        {
            CurrentLayer = CurrentLevelIndex.LayerIndex + 1;

            SceneManager.LoadScene("LevelManager");
        }

        public static void LoseLevel()
        {
            SceneManager.LoadScene("LevelManager");
        }

        public static void WinGame()
        {
            CurrentGameState = GameState.Win;
            SceneManager.LoadScene("FinalScene");
        }

        public static void LoseGame()
        {
            CurrentGameState = GameState.Lose;
            SceneManager.LoadScene("FinalScene");
        }

        public static void RestartGame()
        {
            CurrentLayer = 0;
            CurrentLevelIndex = LevelIndex.Invalid;
            VisitedLevels.Clear();
            CurrentGameState = GameState.Playing;

            SceneManager.LoadScene("LevelManager");
        }
    }
}