using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ.Core
{
    public class RestartGameHelper : MonoBehaviour
    {
        public TMPro.TextMeshProUGUI finalMessage;

        private void Start()
        {
            if (State.CurrentGameState == GameState.Win)
            {
                finalMessage.text = "You Win!";
            }
            else if (State.CurrentGameState == GameState.Lose)
            {
                finalMessage.text = "You Lose!";
            }
        }

        public void RestartGame()
        {
            State.RestartGame();
        }
    }
}

