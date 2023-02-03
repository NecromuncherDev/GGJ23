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
        //Debug.Log($"Stomp collision, {(float)player.health.CurrentHP / (float)player.health.maxHP}, {player.health.CurrentHP} {player.health.maxHP}" );
        if(model.uiLevel != null)
            model.uiLevel.uiHealth.Health = (float)player.health.CurrentHP / (float)player.health.maxHP;
        //Schedule<PlayerDeath>();
    }
}

