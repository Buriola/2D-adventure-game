using System.Collections.Generic;
using Buriola.Gameplay.Animations;
using Buriola.Gameplay.Player.Data;
using Buriola.InputSystem;
using UnityEngine;

namespace Buriola.Gameplay.Player.FSM.SubStates
{
    public sealed class PlayerSwordAttackState : PlayerAttackState
    {
        private readonly int _attack1Hash = AnimationConstants.PLAYER_ATTACK_1_HASH;
        private readonly int _attack2Hash = AnimationConstants.PLAYER_ATTACK_2_HASH;
        private readonly int _attack3Hash = AnimationConstants.PLAYER_ATTACK_3_HASH;
        
        public PlayerSwordAttackState(PlayerController2D player, PlayerStateMachine stateMachine, PlayerData data, int animationHash, int attackCombo) : base(player, stateMachine, data, animationHash, attackCombo)
        {
            CounterToAnim = new Dictionary<int, int>(){ {1, _attack1Hash}, {2, _attack2Hash}, {3, _attack3Hash}};
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            InputController.Instance.GameInputContext.OnActionButton2Pressed -= OnAttackPressed;
            InputController.Instance.GameInputContext.OnActionButton2Pressed += OnAttackPressed;
            
            PlayerController.SetVelocity(Vector2.zero);
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
