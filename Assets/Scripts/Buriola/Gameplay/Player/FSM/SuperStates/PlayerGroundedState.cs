using Buriola.Gameplay.Player.Data;
using UnityEngine;
using Buriola.InputSystem;
using UnityEngine.InputSystem;

namespace Buriola.Gameplay.Player.FSM.SuperStates
{
    public class PlayerGroundedState : PlayerState
    {
        protected Vector2 Input;
        protected float RawInputX;
        private bool IsGrounded;
        private bool JumpInput;
        
        protected PlayerGroundedState(PlayerController2D player, PlayerStateMachine stateMachine, PlayerData data, int animationHash) : base(player, stateMachine, data, animationHash)
        {
            
        }

        public override void OnEnter()
        {
            base.OnEnter();

            InputController.Instance.GameInputContext.OnActionButton0Pressed -= OnJumpPressed;
            InputController.Instance.GameInputContext.OnActionButton0Pressed += OnJumpPressed;
            
            PlayerController.JumpState.ResetJumps();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            Input = PlayerController.InputHandler.MovementAxis;
            RawInputX = PlayerController.InputHandler.RawInputX;
            JumpInput = PlayerController.InputHandler.JumpInput;

            if (!IsGrounded)
            {
                StateMachine.ChangeState(PlayerController.InAirState);
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

            IsGrounded = PlayerController.IsGrounded();
        }

        private void OnJumpPressed(InputAction.CallbackContext context)
        {
            if (context.ReadValueAsButton())
            {
                StateMachine.ChangeState(PlayerController.JumpState);
            }
        }
    }
}
