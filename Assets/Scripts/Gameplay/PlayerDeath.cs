﻿using System.Collections;
using System.Collections.Generic;
using GGJ.Core;
using Platformer.Core;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the player has died.
    /// </summary>
    /// <typeparam name="PlayerDeath"></typeparam>
    public class PlayerDeath : Simulation.Event<PlayerDeath>
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            var playerHealth = model.playerHealth;
            if (playerHealth.IsAlive)
            {
                playerHealth.Die();
            }
            State.LoseLevel();
        }
    }
}