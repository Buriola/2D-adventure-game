using Buriola.Gameplay.Animations;
using Buriola.Gameplay.Player.Data;
using Buriola.Gameplay.Player.FSM.SuperStates;
using Buriola.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Buriola.Gameplay.Player.FSM.SubStates
{
    public class PlayerWallSlideState : PlayerWallState
    {
        public PlayerWallSlideState(PlayerController2D player, PlayerStateMachine stateMachine, PlayerData data, int animationHash) : base(player, stateMachine, data, animationHash)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            InputController.Instance.GameInputContext.OnActionButton0Pressed -= OnJumpPressed;
            InputController.Instance.GameInputContext.OnActionButton0Pressed += OnJumpPressed;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            if (PlayerController.CurrentVelocity.y < -PlayerData.WallSlideMaxSpeed)
            {
                PlayerController.SetVelocityX(0f);
                PlayerController.SetVelocityY(-PlayerData.WallSlideMaxSpeed);
            }
        }

        public override void OnExit()
        {
            base.OnExit();
            InputController.Instance.GameInputContext.OnActionButton0Pressed -= OnJumpPressed;
        }

        public override void Dispose()
        {
            InputController.Instance.GameInputContext.OnActionButton0Pressed -= OnJumpPressed;
        }

        private void OnJumpPressed(InputAction.CallbackContext obj)
        {
            if (obj.ReadValueAsButton())
            {
                Vector2 _jumpVelocity = Vector2.zero;

                if (WallDirection == RawInputX)
                {
                    _jumpVelocity.x = -WallDirection * PlayerData.WallJumpClimb.x;
                    _jumpVelocity.y = PlayerData.WallJumpClimb.y;
                }
                else if (RawInputX == 0f)
                {
                    _jumpVelocity.x = -WallDirection * PlayerData.WallJumpOff.x;
                    _jumpVelocity.y = PlayerData.WallJumpOff.y;
                }
                else
                {
                    _jumpVelocity.x = -WallDirection * PlayerData.WallJumpLeap.x;
                    _jumpVelocity.y = PlayerData.WallJumpLeap.y;
                }
            
                PlayerController.SetVelocity(_jumpVelocity);
                PlayerController.CheckIfShouldFlip(_jumpVelocity.x);
                PlayerController.AnimController.PlayAnimation(AnimationConstants.PLAYER_JUMP_HASH);
                
                StateMachine.ChangeState(PlayerController.InAirState);
            }
        }
    }
}
