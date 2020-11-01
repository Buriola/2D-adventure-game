using Buriola.Gameplay.Player.Data;
using UnityEngine;
using Buriola.InputSystem;
using UnityEngine.InputSystem;

namespace Buriola.Gameplay.Player.FSM.SuperStates
{
    public class PlayerGroundedState : PlayerState
    {
        private bool _isGrounded;
        
        protected Vector2 Input;
        protected float RawInputX;
        protected float RawInputY;
        protected bool ObstacleAbove;
        
        protected PlayerGroundedState(PlayerController2D player, PlayerStateMachine stateMachine, PlayerData data, int animationHash) : base(player, stateMachine, data, animationHash)
        {
            
        }

        public override void OnEnter()
        {
            base.OnEnter();

            PlayerController.Collider.size = PlayerData.NormalColliderSize;
            PlayerController.Collider.offset = PlayerData.NormalColliderOffset;
            
            InputController.Instance.GameInputContext.OnActionButton0Pressed -= OnJumpPressed;
            InputController.Instance.GameInputContext.OnActionButton0Pressed += OnJumpPressed;
            
            PlayerController.JumpState.ResetJumps();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            Input = PlayerController.InputHandler.MovementAxis;
            RawInputX = PlayerController.InputHandler.RawInputX;
            RawInputY = PlayerController.InputHandler.RawInputY;

            if (!_isGrounded)
            {
                StateMachine.ChangeState(PlayerController.InAirState);
                return;
            }

            if (ObstacleAbove || RawInputY < 0f)
            {
                StateMachine.ChangeState(PlayerController.CrouchIdleState);
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

        protected override void DoChecks()
        {
            base.DoChecks();

            _isGrounded = PlayerController.IsGrounded();
            ObstacleAbove = PlayerController.CheckForObstaclesAbovePlayer();
        }

        private void OnJumpPressed(InputAction.CallbackContext context)
        {
            if (context.ReadValueAsButton() && !ObstacleAbove)
            {
                StateMachine.ChangeState(PlayerController.JumpState);
            }
        }
    }
}
