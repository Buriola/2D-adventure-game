using Buriola.Gameplay.Player.Data;
using Buriola.Gameplay.Player.FSM.SuperStates;
using UnityEngine;

namespace Buriola.Gameplay.Player.FSM.SubStates
{
    public sealed class PlayerItemState : PlayerAbilityState
    {
        public PlayerItemState(PlayerController2D player, PlayerStateMachine stateMachine, PlayerData data, int animationHash) : base(player, stateMachine, data, animationHash)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            PlayerController.SetVelocity(Vector2.zero);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            if (!IsGrounded)
            {
                StateMachine.ChangeState(PlayerController.InAirState);
            }
        }

        public override void AnimationFinishTrigger()
        {
            base.AnimationFinishTrigger();
            IsAbilityDone = true;
        }
    }
}
