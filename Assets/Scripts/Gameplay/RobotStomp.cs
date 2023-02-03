using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Gameplay
{

	public class RobotStomp : Simulation.Event<RobotStomp>
	{
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();
        public RobotController robot;
        
        public override void Execute()
        {
            robot.PlayAttack();
            var robotStomp = Schedule<RobotStomp>(10);
            robotStomp.robot = robot;
        }
    }
}
