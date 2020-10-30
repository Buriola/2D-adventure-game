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

            float targetVelocityX = RawInputX * PlayerData.MoveSpeed;
            float xMovement = Mathf.SmoothDamp(PlayerController.CurrentVelocity.x, targetVelocityX, ref _velocityXSmoothing, PlayerData.AccelerationTimeGrounded);
            
            PlayerController.CheckIfShouldFlip(RawInputX);
            PlayerController.SetVelocityX(xMovement);

            if (RawInputX == 0f)
            {
                StateMachine.ChangeState(PlayerController.IdleState);
            }
        }
    }
}
