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
        private float _wallStickTimer;
        private bool _unstickFromWall;

        public PlayerWallState(PlayerController2D player, PlayerStateMachine stateMachine, PlayerData data, int animationHash) : base(player, stateMachine, data, animationHash)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            WallDirection = PlayerController.WallDirectionX;
            _wallStickTimer = 0f;
            _unstickFromWall = false;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            RawInputX = PlayerController.InputHandler.RawInputX;
            
            if (IsGrounded)
            {
                PlayerController.CheckIfShouldFlip(-WallDirection);
                StateMachine.ChangeState(PlayerController.IdleState);
            }

            if (RawInputX != WallDirection && !_unstickFromWall)
            {
                _wallStickTimer += Time.deltaTime;
                if (_wallStickTimer >= PlayerData.WallStickTime)
                {
                    _wallStickTimer = 0f;
                    _unstickFromWall = true;
                }
            }
            else
            {
                _wallStickTimer = 0f;
            }
            
            if (!IsTouchingWall || (RawInputX != WallDirection && _unstickFromWall))
            {
                PlayerController.CheckIfShouldFlip(-WallDirection);
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
