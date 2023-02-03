﻿using static Platformer.Core.Simulation;
using Platformer.Mechanics;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class StompController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("OnTriggerEnter2D" + collider.name);
        var player = collider.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            Debug.Log("OnTriggerEnter2D- player");
            var ev = Schedule<PlayerStompCollision>();
            ev.player = player;
        }
    }
}

