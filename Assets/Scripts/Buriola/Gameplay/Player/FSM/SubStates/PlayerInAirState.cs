using Buriola.Gameplay.Player.Data;
using Buriola.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Buriola.Gameplay.Player.FSM.SubStates
{
    public sealed class PlayerInAirState : PlayerState
    {
        private bool _isGrounded;
        private float _rawInputX;
        private bool _jumpInput;
        private float _velocityXSmoothing;
        private bool _animationSet;
        
        public PlayerInAirState(PlayerController2D player, PlayerStateMachine stateMachine, PlayerData data, int animationHash) : base(player, stateMachine, data, animationHash)
        {
        }

        public override void OnEnter()
        {
            DoChecks();
            
            InputController.Instance.GameInputContext.OnActionButton0Pressed -= OnJumpPressed;
            InputController.Instance.GameInputContext.OnActionButton0Pressed += OnJumpPressed;
            
            StartTime = Time.time;
            IsAnimationFinished = false;
            _animationSet = false;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            _rawInputX = PlayerController.InputHandler.RawInputX;
            _jumpInput = PlayerController.InputHandler.JumpInput;
            
            float targetVelocityX = _rawInputX * PlayerData.MoveSpeed;
            float xMovement = Mathf.SmoothDamp(PlayerController.CurrentVelocity.x, targetVelocityX, ref _velocityXSmoothing, PlayerData.AccelerationTimeAirborne);
            
            PlayerController.CheckIfShouldFlip(_rawInputX);
            PlayerController.SetVelocityX(xMovement);
            
            if (PlayerController.CurrentVelocity.y < 0f && !_animationSet)
            {
                _animationSet = true;
                PlayerController.AnimController.PlayAnimation(AnimationHash);
            }
        }

        public override void OnExit()
        {
            base.OnExit();
            
            InputController.Instance.GameInputContext.OnActionButton0Pressed -= OnJumpPressed;
        }

        protected override void DoChecks()
        {
            base.DoChecks();

            _isGrounded = PlayerController.IsGrounded();
            
            if (_isGrounded && PlayerController.CurrentVelocity.y < 0.01f)
            {
                StateMachine.ChangeState(PlayerController.LandState);
            }
        }
        
        public override void Dispose()
        {
            InputController.Instance.GameInputContext.OnActionButton0Pressed -= OnJumpPressed;
        }

        private void OnJumpPressed(InputAction.CallbackContext obj)
        {
            if (obj.ReadValueAsButton())
            {
                if (PlayerController.JumpState.CanJumpAgain())
                {
                    StateMachine.ChangeState(PlayerController.JumpState);
                }
            }
        }
    }
}
