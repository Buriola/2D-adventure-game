using Buriola.Gameplay.Player.Data;
using Buriola.Gameplay.Player.FSM.SuperStates;

namespace Buriola.Gameplay.Player.FSM.SubStates
{
    public class PlayerLandState : PlayerGroundedState
    {
        public PlayerLandState(PlayerController2D player, PlayerStateMachine stateMachine, PlayerData data, string animationName) : base(player, stateMachine, data, animationName)
        {
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (RawInputX != 0)
            {
                StateMachine.ChangeState(PlayerController.MoveState);
            }
            else
            {
                StateMachine.ChangeState(PlayerController.IdleState);
            }
        }
    }
}
