using Buriola.Gameplay.Player.Data;
using Buriola.Gameplay.Player.FSM.SuperStates;
using UnityEngine;

namespace Buriola.Gameplay.Player.FSM.SubStates
{
    public sealed class PlayerLedgeJumpState : PlayerAbilityState
    {
        private int _wallDirection;
        
        public PlayerLedgeJumpState(PlayerController2D player, PlayerStateMachine stateMachine, PlayerData data, int animationHash) : base(player, stateMachine, data, animationHash)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            _wallDirection = PlayerController.WallDirectionX;
            
            Vector2 _jumpVelocity = Vector2.zero;

            _jumpVelocity.x = _wallDirection * PlayerData.LedgeJumpClimb.x;
            _jumpVelocity.y = PlayerData.LedgeJumpClimb.y;
            
            PlayerController.SetVelocity(_jumpVelocity);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (PlayerController.CurrentVelocity.y < 0)
            {
                IsAbilityDone = true;
            }
        }
    }
}
