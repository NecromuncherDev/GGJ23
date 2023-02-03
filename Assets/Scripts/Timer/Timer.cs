using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ.Core
{
    public class Timer : MonoSingleton<Timer>
    {
        public float time = 60.0f;

        private float initTime = 60.0f;

        private void Awake()
        {
            initTime = time;

            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            if (State.CurrentGameState != GameState.Playing)
                return;

            time -= Time.deltaTime;
            if (time <= 0.0f)
            {
                time = 0.0f;
                State.LoseGame();
            }
        }

        public void Reset()
        {
            time = initTime;
        }
    }
}
