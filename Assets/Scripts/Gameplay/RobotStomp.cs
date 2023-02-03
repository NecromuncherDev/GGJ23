using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Gameplay
{

	public class RobotStomp : Simulation.Event<PlayerEnemyCollision>
	{
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();
        public Robot robot;
        
        public override void Execute()
        {
            robot.PlayAttack();
            var robotStomp = Schedule<RobotStomp>(5);
            robotStomp.robot = robot;
        }
    }
}
