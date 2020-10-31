using Buriola.Gameplay.Player.Data;
using Buriola.Gameplay.Player.FSM.SuperStates;

namespace Buriola.Gameplay.Player.FSM.SubStates
{
    public sealed class PlayerIdleState : PlayerGroundedState
    {
        public PlayerIdleState(PlayerController2D player, PlayerStateMachine stateMachine, PlayerData data, int animationHash) : base(player, stateMachine, data, animationHash)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            PlayerController.SetVelocityX(0f);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (Input.x != 0f)
            {
                StateMachine.ChangeState(PlayerController.MoveState);
            }
        }
    }
}
