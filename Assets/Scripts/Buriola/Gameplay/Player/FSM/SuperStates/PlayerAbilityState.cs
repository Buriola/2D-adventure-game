using Buriola.Gameplay.Player.Data;

namespace Buriola.Gameplay.Player.FSM.SuperStates
{
    public class PlayerAbilityState : PlayerState
    {
        protected bool IsAbilityDone;
        protected bool IsGrounded;

        protected PlayerAbilityState(PlayerController2D player, PlayerStateMachine stateMachine, PlayerData data, int animationHash) : base(player, stateMachine, data, animationHash)
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
                if (IsGrounded && PlayerController.CurrentVelocity.y < 0.01f)
                {
                    StateMachine.ChangeState(PlayerController.IdleState);
                }
                else
                {
                    StateMachine.ChangeState(PlayerController.InAirState);
                }
            }
        }

        protected override void DoChecks()
        {
            base.DoChecks();

            IsGrounded = PlayerController.IsGrounded();
        }
    }
}
