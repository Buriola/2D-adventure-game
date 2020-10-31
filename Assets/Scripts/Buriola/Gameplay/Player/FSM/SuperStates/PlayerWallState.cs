using Buriola.Gameplay.Player.Data;
using UnityEngine;

namespace Buriola.Gameplay.Player.FSM.SuperStates
{
    public class PlayerWallState : PlayerState
    {
        protected float RawInputX;
        protected bool IsGrounded;
        protected bool IsTouchingWall;
        protected int WallDirection;

        public PlayerWallState(PlayerController2D player, PlayerStateMachine stateMachine, PlayerData data, int animationHash) : base(player, stateMachine, data, animationHash)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            WallDirection = PlayerController.WallDirectionX;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            RawInputX = PlayerController.InputHandler.RawInputX;
            
            if (IsGrounded)
            {
                StateMachine.ChangeState(PlayerController.IdleState);
            }
            
            if (!IsTouchingWall || RawInputX != WallDirection)
            {
                StateMachine.ChangeState(PlayerController.InAirState);
            }
        }

        protected override void DoChecks()
        {
            base.DoChecks();

            IsGrounded = PlayerController.IsGrounded();
            IsTouchingWall = PlayerController.IsTouchingWall();
        }
    }
}
