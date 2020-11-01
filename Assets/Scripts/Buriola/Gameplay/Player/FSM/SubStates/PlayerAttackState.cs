using System.Collections.Generic;
using Buriola.Gameplay.Animations;
using Buriola.Gameplay.Player.Data;
using Buriola.Gameplay.Player.FSM.SuperStates;
using Buriola.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Buriola.Gameplay.Player.FSM.SubStates
{
    public sealed class PlayerAttackState : PlayerAbilityState
    {
        private readonly float _inputHoldTime = 0.25f;
        private float _inputTimer;
        private bool _inputRegistered;
        private float _velocityXSmoothing;

        private readonly int _attack1Hash = AnimationConstants.PLAYER_ATTACK_1_HASH;
        private readonly int _attack2Hash = AnimationConstants.PLAYER_ATTACK_2_HASH;
        private readonly int _attack3Hash = AnimationConstants.PLAYER_ATTACK_3_HASH;

        private int _attackCounter;
        private readonly int _attackCombo;

        private readonly Dictionary<int, int> _counterToAnim;
        
        public PlayerAttackState(PlayerController2D player, PlayerStateMachine stateMachine, PlayerData data, int animationHash) : base(player, stateMachine, data, animationHash)
        {
            _attackCombo = 3;
            _counterToAnim = new Dictionary<int, int> {[1] = _attack1Hash, [2] = _attack2Hash, [3] = _attack3Hash};
        }

        public override void OnEnter()
        {
            InputController.Instance.GameInputContext.OnActionButton2Pressed -= OnAttackPressed;
            InputController.Instance.GameInputContext.OnActionButton2Pressed += OnAttackPressed;
            
            IsAbilityDone = false;
            
            StartTime = Time.time;
            IsAnimationFinished = false;
            _inputTimer = 0f;

            _attackCounter = 1;
            AnimationHash = _counterToAnim[_attackCounter];
            
            PlayerController.SetVelocity(Vector2.zero);
            PlayerController.AnimController.PlayAnimation(AnimationHash);
            
            _attackCounter++;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (_inputRegistered)
            {
                _inputTimer += Time.deltaTime;
                if (_inputTimer >= _inputHoldTime)
                {
                    _inputRegistered = false;
                    _inputTimer = 0f;
                }
            }
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

        public override void AnimationFinishTrigger()
        {
            base.AnimationFinishTrigger();

            if (_inputRegistered && _attackCounter <= _attackCombo)
            {
                IsAnimationFinished = false;
                
                AnimationHash = _counterToAnim[_attackCounter];
                PlayerController.AnimController.PlayAnimation(AnimationHash);
                _attackCounter++;
            }
            else
            {
                StateMachine.ChangeState(PlayerController.IdleState);
            }
        }

        private void OnAttackPressed(InputAction.CallbackContext obj)
        {
            if (obj.ReadValueAsButton())
            {
                _inputRegistered = true;
                _inputTimer = 0f;
            }
        }
    }
}
