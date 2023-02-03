using static Platformer.Core.Simulation;
using Platformer.Mechanics;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class StompController : MonoBehaviour
{
    float throttlingInterval = 1;
    float lastCollision = 0;
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("OnTriggerEnter2D" + collider.name);
        var player = collider.gameObject.GetComponent<PlayerController>();
        if (player != null && Time.time - lastCollision > throttlingInterval)
        {
            lastCollision = Time.time;
            Debug.Log("OnTriggerEnter2D- player");
            var ev = Schedule<PlayerStompCollision>();
            ev.player = player;
        }
    }
}

