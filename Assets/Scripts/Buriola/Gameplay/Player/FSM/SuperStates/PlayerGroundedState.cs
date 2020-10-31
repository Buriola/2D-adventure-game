using Buriola.Gameplay.Player.Data;
using UnityEngine;

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

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            Input = PlayerController.InputHandler.MovementAxis;
            RawInputX = PlayerController.InputHandler.RawInputX;
            JumpInput = PlayerController.InputHandler.JumpInput;

            if (JumpInput)
            {
                StateMachine.ChangeState(PlayerController.JumpState);
            }

            if (!IsGrounded)
            {
                StateMachine.ChangeState(PlayerController.InAirState);
            }
        }

        public override void DoChecks()
        {
            base.DoChecks();

            IsGrounded = PlayerController.IsGrounded();
        }
    }
}
