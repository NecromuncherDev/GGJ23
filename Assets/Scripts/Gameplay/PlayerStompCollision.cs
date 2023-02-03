using Platformer.Core;
using static Platformer.Core.Simulation;
using Platformer.Gameplay;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;

public class PlayerStompCollision : Simulation.Event<PlayerStompCollision>
{
    PlatformerModel model = Simulation.GetModel<PlatformerModel>();
    public PlayerController player;

    public override void Execute()
    {
        player.health.Decrement();
        //Schedule<PlayerDeath>();
    }
}

