using Buriola.Gameplay.Animations;
using Buriola.Gameplay.Player.Data;
using UnityEngine;

namespace Buriola.Gameplay.Player.FSM.SubStates
{
    public sealed class PlayerLedgeClimbState : PlayerState
    {
        private Vector2 _detectedPosition;
        private Vector2 _cornerPosition;
        private Vector2 _startPosition;
        private Vector2 _endPosition;

        private bool _isHanging;
        private bool _isClimbing;
        
        private float _xInput;
        private float _yInput;
        
        public PlayerLedgeClimbState(PlayerController2D player, PlayerStateMachine stateMachine, PlayerData data, int animationHash) : base(player, stateMachine, data, animationHash)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            PlayerController.ToggleGravity();
            PlayerController.SetVelocity(Vector2.zero);
            
            _cornerPosition = PlayerController.FindCornerPosition();

            float xStartPosition = _cornerPosition.x - (PlayerController.DirectionX * PlayerData.LedgeStartOffset.x);
            float yStartPosition = _cornerPosition.y - PlayerData.LedgeStartOffset.y;
            _startPosition.Set(xStartPosition, yStartPosition);

            float xEndPosition = _cornerPosition.x + (PlayerController.DirectionX * PlayerData.LedgeEndOffset.x);
            float yEndPosition = _cornerPosition.y + PlayerData.LedgeEndOffset.y;
            _endPosition.Set(xEndPosition, yEndPosition);

            PlayerController.transform.position = _startPosition;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (IsAnimationFinished) return;
            
            _xInput = PlayerController.InputHandler.RawInputX;
            _yInput = PlayerController.InputHandler.RawInputY;

            PlayerController.transform.position = _startPosition;
            
            if (_xInput == PlayerController.DirectionX && _isHanging && !_isClimbing)
            {
                _isClimbing = true;
                _isHanging = false;
                PlayerController.AnimController.PlayAnimation(AnimationConstants.PLAYER_LEDGE_CLIMB_HASH);
            }

            if (_yInput < 0f && _isHanging && !_isClimbing)
            {
                StateMachine.ChangeState(PlayerController.InAirState);
            }
        }

        public override void OnExit()
        {
            base.OnExit();

            _isHanging = false;
            
            if (_isClimbing)
            {
                PlayerController.transform.position = _endPosition;
                _isClimbing = false;
            }
            
            PlayerController.ToggleGravity();
        }

        public override void AnimationTrigger()
        {
            _isHanging = true;
        }

        public override void AnimationFinishTrigger()
        {
            base.AnimationFinishTrigger();

            StateMachine.ChangeState(PlayerController.LedgeJumpState);
        }

        public void SetDetectedPosition(Vector2 position) => _detectedPosition = position;
    }
}
