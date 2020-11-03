using Buriola.Gameplay.Animations;
using Buriola.Gameplay.Player.Data;
using Buriola.Gameplay.Player.FSM.SuperStates;
using UnityEngine;
using Buriola.InputSystem;
using UnityEngine.InputSystem;

namespace Buriola.Gameplay.Player.FSM.SubStates
{
    public sealed class PlayerJumpState : PlayerAbilityState
    {
        private readonly float _gravity;
        private float _maxJumpVelocity;
        private float _minJumpVelocity;
        private int _amountOfJumpsLeft;

        private bool _somersault;
        private readonly int _jumpHash = AnimationConstants.PLAYER_JUMP_HASH;
        private readonly int _somersaultHash = AnimationConstants.PLAYER_SOMERSAULT_HASH;
        
        public PlayerJumpState(PlayerController2D player, PlayerStateMachine stateMachine, PlayerData data, int animationHash) : base(player, stateMachine, data, animationHash)
        {
            _gravity = -(2 * PlayerData.MaxJumpHeight) / Mathf.Pow(PlayerData.TimeToJumpApex, 2);
            _amountOfJumpsLeft = PlayerData.JumpAmount;
        }
        
        public override void OnEnter()
        {
            if (_somersault)
            {
                AnimationHash = _somersaultHash;
                _somersault = false;
            }
            else
            {
                AnimationHash = _jumpHash;
            }
            
            base.OnEnter();

            InputController.Instance.GameInputContext.OnActionButton0Released -= OnJumpEnded;
            InputController.Instance.GameInputContext.OnActionButton0Released += OnJumpEnded;
            
            _maxJumpVelocity = Mathf.Abs(_gravity) * PlayerData.TimeToJumpApex;
            _minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(_gravity) * PlayerData.MinJumpHeight);

            PlayerController.SetVelocityY(_maxJumpVelocity);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (PlayerController.CurrentVelocity.y < 0)
            {
                IsAbilityDone = true;
            }
        }

        public override void OnExit()
        {
            base.OnExit();

            InputController.Instance.GameInputContext.OnActionButton0Released -= OnJumpEnded;
        }

        public bool CanJumpAgain()
        {
            bool canJumpAgain = _amountOfJumpsLeft > 0;

            if (canJumpAgain)
            {
                _somersault = true;
            }
            
            _amountOfJumpsLeft--;
            if (_amountOfJumpsLeft <= 0) _amountOfJumpsLeft = 0;
            
            return canJumpAgain;
        }

        public void ResetJumps()
        {
            _amountOfJumpsLeft = PlayerData.JumpAmount;
        }

        public override void Dispose()
        {
            InputController.Instance.GameInputContext.OnActionButton0Released -= OnJumpEnded;
        }

        private void OnJumpEnded(InputAction.CallbackContext context)
        {
            if (PlayerController.CurrentVelocity.y > _minJumpVelocity)
            {
                PlayerController.SetVelocityY(_minJumpVelocity);
                IsAbilityDone = true;
            }
        }
    }
}
