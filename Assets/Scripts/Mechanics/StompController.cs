﻿using static Platformer.Core.Simulation;
using Platformer.Mechanics;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class StompController : MonoBehaviour
{
    float throttlingInterval = 2;
    float lastCollision = 0;
    void OnTriggerEnter2D(Collider2D collider)
    {
        var playerHealth = collider.gameObject.GetComponent<Health>();
        if (playerHealth != null && Time.time - lastCollision > throttlingInterval)
        {
            lastCollision = Time.time;
            var ev = Schedule<PlayerStompCollision>();
            ev.playerHealth = playerHealth;
        }
    }
}

