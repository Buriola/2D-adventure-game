using System.Collections.Generic;
using Buriola.Gameplay.Player.Data;
using Buriola.Gameplay.Player.FSM.SuperStates;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Buriola.Gameplay.Player.FSM.SubStates
{
    public abstract class PlayerAttackState : PlayerAbilityState
    {
        private float _inputTimer;
        private bool _inputRegistered;
        private int _attackCounter;

        private readonly float _inputHoldTime;
        protected Dictionary<int, int> CounterToAnim;
        private readonly int _attackCombo;

        protected PlayerAttackState(PlayerController2D player, PlayerStateMachine stateMachine, PlayerData data, int animationHash, int attackCombo) : base(player, stateMachine, data, animationHash)
        {
            _attackCombo = attackCombo;
            _inputHoldTime = data.InputBufferTime;
        }

        public override void OnEnter()
        {
            IsAbilityDone = false;
            StartTime = Time.time;
            IsAnimationFinished = false;
            
            _inputTimer = 0f;
            _attackCounter = 1;
            
            AnimationHash = CounterToAnim[_attackCounter];
            _attackCounter++;
            
            PlayerController.SetVelocity(Vector2.zero);
            PlayerController.AnimController.PlayAnimation(AnimationHash);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (_inputRegistered)
            {
                _inputTimer += Time.deltaTime;
                if (_inputTimer >= _inputHoldTime)
                {
                    UseAttackInput();
                }
            }
        }

        public override void AnimationFinishTrigger()
        {
            base.AnimationFinishTrigger();

            if (_inputRegistered && _attackCounter <= _attackCombo)
            {
                IsAnimationFinished = false;
                
                AnimationHash = CounterToAnim[_attackCounter];
                _attackCounter++;
                
                UseAttackInput();
                
                PlayerController.AnimController.PlayAnimation(AnimationHash);
            }
            else
            {
                IsAbilityDone = true;
            }
        }

        protected void OnAttackPressed(InputAction.CallbackContext obj)
        {
            if (obj.ReadValueAsButton())
            {
                _inputRegistered = true;
                _inputTimer = 0f;
            }
        }

        private void UseAttackInput()
        {
            _inputRegistered = false;
            _inputTimer = 0f;
        }
    }
}
