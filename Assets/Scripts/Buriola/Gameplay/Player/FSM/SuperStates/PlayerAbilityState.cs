using Buriola.Gameplay.Player.Data;

namespace Buriola.Gameplay.Player.FSM.SuperStates
{
    public class PlayerAbilityState : PlayerState
    {
        protected bool IsAbilityDone;
        private bool _isGrounded;

        public PlayerAbilityState(PlayerController2D player, PlayerStateMachine stateMachine, PlayerData data, int animationHash) : base(player, stateMachine, data, animationHash)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            IsAbilityDone = false;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (IsAbilityDone)
            {
                if (_isGrounded && PlayerController.CurrentVelocity.y < 0.01f)
                {
                    StateMachine.ChangeState(PlayerController.IdleState);
                }
                else
                {
                    StateMachine.ChangeState(PlayerController.InAirState);
                }
            }
        }

        public override void DoChecks()
        {
            base.DoChecks();

            _isGrounded = PlayerController.IsGrounded();
        }
    }
}
