using Platformer.Gameplay;
using Platformer.Mechanics;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace GGJ.Core {
    public class PortalBehavior : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collider)
        {
            Debug.Log("PORTAL");
            State.LoseLevel();
        }
    } }
