using Buriola.Gameplay.Player.Data;
using UnityEngine;

namespace Buriola.Gameplay.Player.FSM.SubStates
{
    public sealed class PlayerInAirState : PlayerState
    {
        private bool _isGrounded;
        private float _rawInputX;
        private float _velocityXSmoothing;
        
        public PlayerInAirState(PlayerController2D player, PlayerStateMachine stateMachine, PlayerData data, string animationName) : base(player, stateMachine, data, animationName)
        {
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            _rawInputX = PlayerController.InputHandler.RawInputX;
            
            float targetVelocityX = _rawInputX * PlayerData.MoveSpeed;
            float xMovement = Mathf.SmoothDamp(PlayerController.CurrentVelocity.x, targetVelocityX, ref _velocityXSmoothing, PlayerData.AccelerationTimeAirborne);
            
            PlayerController.CheckIfShouldFlip(_rawInputX);
            PlayerController.SetVelocityX(xMovement);
            
            if (_isGrounded && PlayerController.CurrentVelocity.y < 0.01f)
            {
                StateMachine.ChangeState(PlayerController.LandState);
            }
        }

        public override void DoChecks()
        {
            base.DoChecks();

            _isGrounded = PlayerController.IsGrounded();
        }
    }
}
