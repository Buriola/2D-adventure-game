using Buriola.Gameplay.Player.Data;
using Buriola.Gameplay.Player.FSM.SuperStates;

namespace Buriola.Gameplay.Player.FSM.SubStates
{
    public sealed class PlayerIdleState : PlayerGroundedState
    {
        public PlayerIdleState(PlayerController2D player, PlayerStateMachine stateMachine, PlayerData data, string animationName) : base(player, stateMachine, data, animationName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            _playerController.SetVelocityX(0f);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (_input.x != 0f)
            {
                _stateMachine.ChangeState(_playerController.MoveState);
            }
        }
    }
}
