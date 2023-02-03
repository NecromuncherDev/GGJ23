using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;
using static Platformer.Core.Simulation;

public class ToggleStompActive : Simulation.Event<ToggleStompActive>
{

    public StompController stompController;
    public bool active;

    public override void Execute()
    {
        BoxCollider2D collider = stompController.gameObject.GetComponent<BoxCollider2D>();
        collider.enabled = active;
        if (active)
        {
            var toggle = Schedule<ToggleStompActive>(1f);
            toggle.active = false;
            toggle.stompController = stompController;
        }
    }
}

