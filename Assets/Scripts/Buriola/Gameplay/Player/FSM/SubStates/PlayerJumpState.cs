using Buriola.Gameplay.Player.Data;
using Buriola.Gameplay.Player.FSM.SuperStates;
using UnityEngine;

namespace Buriola.Gameplay.Player.FSM.SubStates
{
    public sealed class PlayerJumpState : PlayerAbilityState
    {
        private readonly float _gravity;
        private float _maxJumpVelocity;
        private float _minJumpVelocity;
        private float _time;
        private float _yPosition;
        private float _finalYPosition;
        
        public PlayerJumpState(PlayerController2D player, PlayerStateMachine stateMachine, PlayerData data, int animationHash) : base(player, stateMachine, data, animationHash)
        {
            _gravity = -(2 * PlayerData.MaxJumpHeight) / Mathf.Pow(PlayerData.TimeToJumpApex, 2);
            Physics2D.gravity = new Vector2(0f, _gravity);
        }
        
        public override void OnEnter()
        {
            base.OnEnter();

            _time = 0f;
            _maxJumpVelocity = Mathf.Abs(_gravity) * PlayerData.TimeToJumpApex;
            _minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(_gravity) * PlayerData.MinJumpHeight);
            _yPosition = PlayerController.gameObject.transform.localPosition.y;
            _finalYPosition = _yPosition + PlayerData.MaxJumpHeight;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (PlayerController.InputHandler.JumpInput)
            {
                _time += Time.deltaTime;
                PlayerController.SetVelocityY(_maxJumpVelocity);
                
                if (_time >= PlayerData.TimeToJumpApex || PlayerController.gameObject.transform.localPosition.y >= _finalYPosition)
                {
                    IsAbilityDone = true;
                }
            }
            else
            {
                if (PlayerController.CurrentVelocity.y > _minJumpVelocity)
                {
                    PlayerController.SetVelocityY(_minJumpVelocity);
                    IsAbilityDone = true;
                }
            }
        }
    }
}
