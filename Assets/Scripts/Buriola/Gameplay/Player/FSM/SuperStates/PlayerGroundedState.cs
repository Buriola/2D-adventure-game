using Buriola.Gameplay.Player.Data;
using UnityEngine;
using Buriola.InputSystem;
using UnityEngine.InputSystem;

namespace Buriola.Gameplay.Player.FSM.SuperStates
{
    public class PlayerGroundedState : PlayerState
    {
        protected bool IsGrounded;
        
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
            InputController.Instance.GameInputContext.OnActionButton2Pressed -= OnAttackPressed;
            InputController.Instance.GameInputContext.OnActionButton2Pressed += OnAttackPressed;
            InputController.Instance.GameInputContext.OnActionButton1Pressed -= OnSecondaryAttackPressed;
            InputController.Instance.GameInputContext.OnActionButton1Pressed += OnSecondaryAttackPressed;
            InputController.Instance.GameInputContext.OnActionButton3Pressed -= OnSlidePressed;
            InputController.Instance.GameInputContext.OnActionButton3Pressed += OnSlidePressed;
            
            PlayerController.JumpState.ResetJumps();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            Input = PlayerController.InputHandler.MovementAxis;
            RawInputX = PlayerController.InputHandler.RawInputX;
            RawInputY = PlayerController.InputHandler.RawInputY;

            if (!IsGrounded)
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
            
            InputController.Instance.GameInputContext.OnActionButton1Pressed -= OnSecondaryAttackPressed;
            InputController.Instance.GameInputContext.OnActionButton2Pressed -= OnAttackPressed;
            InputController.Instance.GameInputContext.OnActionButton0Pressed -= OnJumpPressed;
            InputController.Instance.GameInputContext.OnActionButton3Pressed -= OnSlidePressed;
        }

        public override void Dispose()
        {
            InputController.Instance.GameInputContext.OnActionButton1Pressed -= OnSecondaryAttackPressed;
            InputController.Instance.GameInputContext.OnActionButton2Pressed -= OnAttackPressed;
            InputController.Instance.GameInputContext.OnActionButton0Pressed -= OnJumpPressed;
            InputController.Instance.GameInputContext.OnActionButton3Pressed -= OnSlidePressed;
        }

        protected override void DoChecks()
        {
            base.DoChecks();

            IsGrounded = PlayerController.IsGrounded();
            ObstacleAbove = PlayerController.CheckForObstaclesAbovePlayer();
        }

        private void OnJumpPressed(InputAction.CallbackContext context)
        {
            if (context.ReadValueAsButton() && !ObstacleAbove)
            {
                StateMachine.ChangeState(PlayerController.JumpState);
            }
        }

        private void OnAttackPressed(InputAction.CallbackContext context)
        {
            if (context.ReadValueAsButton() && !ObstacleAbove)
            {
                StateMachine.ChangeState(PlayerController.SwordAttackState);
            }
        }

        private void OnSecondaryAttackPressed(InputAction.CallbackContext context)
        {
            if (context.ReadValueAsButton() && !ObstacleAbove)
            {
                StateMachine.ChangeState(PlayerController.HandAttackState);
            }
        }

        private void OnSlidePressed(InputAction.CallbackContext context)
        {
            if (context.ReadValueAsButton() && !ObstacleAbove)
            {
                StateMachine.ChangeState(PlayerController.SlideState);
            }
        }
    }
}
