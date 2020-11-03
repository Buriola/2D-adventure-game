using System.Collections.Generic;
using Buriola.Gameplay.Animations;
using UnityEngine;
using Buriola.Gameplay.Player.Data;
using Buriola.InputSystem;

namespace Buriola.Gameplay.Player.FSM.SubStates
{
    public sealed class PlayerAirAttackState : PlayerAttackState
    {
        private float _rawInputX;
        private float _velocityXSmoothing;

        private readonly int _attack1Hash = AnimationConstants.PLAYER_AIR_ATTACK_1_HASH;
        private readonly int _attack2Hash = AnimationConstants.PLAYER_AIR_ATTACK_2_HASH;

        public PlayerAirAttackState(PlayerController2D player, PlayerStateMachine stateMachine, PlayerData data, int animationHash, int attackCombo) : base(player, stateMachine, data, animationHash, attackCombo)
        {
            CounterToAnim = new Dictionary<int, int>(){ {1, _attack1Hash}, {2, _attack2Hash}};
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            InputController.Instance.GameInputContext.OnActionButton2Pressed -= OnAttackPressed;
            InputController.Instance.GameInputContext.OnActionButton2Pressed += OnAttackPressed;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            if (IsGrounded && PlayerController.CurrentVelocity.y < 0.01f)
            {
                IsAbilityDone = true;
                return;
            }
            
            _rawInputX = PlayerController.InputHandler.RawInputX;
            
            float targetVelocityX = _rawInputX * PlayerData.MoveSpeed;
            float xMovement = Mathf.SmoothDamp(PlayerController.CurrentVelocity.x, targetVelocityX, ref _velocityXSmoothing, PlayerData.AccelerationTimeAirborne);
            
            PlayerController.CheckIfShouldFlip(_rawInputX);
            PlayerController.SetVelocityX(xMovement);
        }

        public override void OnExit()
        {
            base.OnExit();
            InputController.Instance.GameInputContext.OnActionButton2Pressed -= OnAttackPressed;
        }

        public override void Dispose()
        {
            InputController.Instance.GameInputContext.OnActionButton2Pressed -= OnAttackPressed;
        }
    }
}
