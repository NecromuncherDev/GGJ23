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
        public static int CurrentLayerIndex = 0;
        public static LevelIndex CurrentLevelIndex = LevelIndex.Invalid;
        public static HashSet<LevelIndex> VisitedLevels = new HashSet<LevelIndex>();
        public static HashSet<LevelIndex> WonLevels = new HashSet<LevelIndex>();

        public static GameState CurrentGameState = GameState.Playing;
        public static bool isLastLevelWon = false;

        public static void MarkVisited(LevelIndex levelIndex)
        {
            CurrentLevelIndex = levelIndex;
            if (VisitedLevels.Contains(levelIndex))
                return;

            VisitedLevels.Add(levelIndex);
        }

        public static void WinLevel()
        {
            WonLevels.Add(CurrentLevelIndex);
            CurrentLayerIndex = CurrentLevelIndex.LayerIndex + 1;
            isLastLevelWon = true;

            SceneManager.LoadScene("LevelManager");
        }

        public static void LoseLevel()
        {
            isLastLevelWon = false;

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
            CurrentLayerIndex = 0;
            CurrentLevelIndex = LevelIndex.Invalid;
            VisitedLevels.Clear();
            WonLevels.Clear();
            CurrentGameState = GameState.Playing;

            Timer.instance.Reset();

            SceneManager.LoadScene("LevelManager");
        }
    }
}