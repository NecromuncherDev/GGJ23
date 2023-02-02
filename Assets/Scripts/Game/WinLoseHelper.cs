using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ.Core
{
    public class WinLoseHelper : MonoBehaviour
    {
        public static void WinLevel()
        {
            State.WinLevel();
        }

        public static void LoseLevel()
        {
            State.LoseLevel();
        }
    }
}