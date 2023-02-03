using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ.Core
{

    public class TimerUI : MonoBehaviour
    {
        private TMPro.TMP_Text timeText;

        private void Awake()
        {
            timeText = GetComponent<TMPro.TMP_Text>();
        }

        private void Update()
        {
            // Format "%.2f s"
            timeText.text = string.Format("{0:F2} s", Timer.instance.time);
        }
    }
}
