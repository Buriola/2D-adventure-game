using System.Collections.Generic;
using Buriola.Gameplay.Animations;
using Buriola.Gameplay.Player.Data;
using Buriola.InputSystem;
using UnityEngine;

namespace Buriola.Gameplay.Player.FSM.SubStates
{
    public sealed class PlayerHandAttackState : PlayerAttackState
    {
        private readonly int _attack1Hash = AnimationConstants.PLAYER_PUNCH_1_HASH;
        private readonly int _attack2Hash = AnimationConstants.PLAYER_PUNCH_2_HASH;
        private readonly int _attack3Hash = AnimationConstants.PLAYER_PUNCH_3_HASH;
        private readonly int _attack4Hash = AnimationConstants.PLAYER_KICK_1_HASH;
        private readonly int _attack5Hash = AnimationConstants.PLAYER_KICK_2_HASH;
        
        public PlayerHandAttackState(PlayerController2D player, PlayerStateMachine stateMachine, PlayerData data, int animationHash, int attackCombo) : base(player, stateMachine, data, animationHash, attackCombo)
        {
            CounterToAnim = new Dictionary<int, int>(){ {1, _attack1Hash}, {2, _attack2Hash}, {3, _attack3Hash}, {4, _attack4Hash}, {5, _attack5Hash}};
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            InputController.Instance.GameInputContext.OnActionButton1Pressed -= OnAttackPressed;
            InputController.Instance.GameInputContext.OnActionButton1Pressed += OnAttackPressed;
            
            PlayerController.SetVelocity(Vector2.zero);
        }
        
        public override void OnExit()
        {
            base.OnExit();
            InputController.Instance.GameInputContext.OnActionButton1Pressed -= OnAttackPressed;
        }

        public override void Dispose()
        {
            InputController.Instance.GameInputContext.OnActionButton1Pressed -= OnAttackPressed;
        }
    }
}
