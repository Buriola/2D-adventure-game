using Buriola.Gameplay.Player.Data;
using Buriola.Gameplay.Player.FSM.SuperStates;
using UnityEngine;

namespace Buriola.Gameplay.Player.FSM.SubStates
{
    public sealed class PlayerMoveState : PlayerGroundedState
    {
        private float _velocityXSmoothing;
        
        public PlayerMoveState(PlayerController2D player, PlayerStateMachine stateMachine, PlayerData data, string animationName) : base(player, stateMachine, data, animationName)
        {
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            float targetVelocityX = _input.x * _playerData.MoveSpeed;
            float xMovement = Mathf.SmoothDamp(_playerController.CurrentVelocity.x, targetVelocityX, ref _velocityXSmoothing, _playerData.AccelerationTimeGrounded);
            
            _playerController.SetVelocityX(xMovement);
            
            if (_input.x == 0f)
            {
                _stateMachine.ChangeState(_playerController.IdleState);
            }
        }
    }
}
