using Buriola.Gameplay.Player.Data;
using Buriola.Gameplay.Player.FSM.SuperStates;
using UnityEngine;

namespace Buriola.Gameplay.Player.FSM.SubStates
{
    public sealed class PlayerCrouchMoveState : PlayerGroundedState
    {
        private float _velocityXSmoothing;
        
        public PlayerCrouchMoveState(PlayerController2D player, PlayerStateMachine stateMachine, PlayerData data, int animationHash) : base(player, stateMachine, data, animationHash)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            PlayerController.Collider.size = PlayerData.CrouchedColliderSize;
            PlayerController.Collider.offset = PlayerData.CrouchedColliderOffset;
        }

        public override void OnUpdate()
        {
            if (!IsGrounded)
            {
                StateMachine.ChangeState(PlayerController.InAirState);
                return;
            }
            
            RawInputX = PlayerController.InputHandler.RawInputX;
            RawInputY = PlayerController.InputHandler.RawInputY;
            
            float targetVelocityX = RawInputX * PlayerData.CrouchedMoveSpeed;
            float xMovement = Mathf.SmoothDamp(PlayerController.CurrentVelocity.x, targetVelocityX, ref _velocityXSmoothing, PlayerData.AccelerationTimeGrounded);
            
            PlayerController.CheckIfShouldFlip(RawInputX);
            PlayerController.SetVelocityX(xMovement);
            
            if (RawInputX == 0 || (RawInputY >= 0f && !ObstacleAbove))
            {
                PlayerController.SetVelocityX(0f);
                StateMachine.ChangeState(PlayerController.CrouchIdleState);
            }
        }
    }
}
