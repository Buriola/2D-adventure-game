using Buriola.Gameplay.Animations;
using Buriola.Gameplay.Player.Data;
using Buriola.Gameplay.Player.FSM.SuperStates;
using UnityEngine;

namespace Buriola.Gameplay.Player.FSM.SubStates
{
    public sealed class PlayerSlideState : PlayerAbilityState
    {
        private Vector2 _slideDirection;
        private float _timeToFinishSlide;
        private float _timer;
        private float _velocityXSmoothing;

        //private bool _playStandAnimation;

        public PlayerSlideState(PlayerController2D player, PlayerStateMachine stateMachine, PlayerData data, int animationHash) : base(player, stateMachine, data, animationHash)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            PlayerController.SetVelocity(Vector2.zero);
            PlayerController.CombatController.SetInvencibility(true);

            _slideDirection = Vector2.right * PlayerController.DirectionX;
            
            PlayerController.Collider.direction = CapsuleDirection2D.Horizontal;
            PlayerController.Collider.size = PlayerData.SlidingColliderSize;
            PlayerController.Collider.offset = PlayerData.SlidingColliderOffset;

            _timer = 0f;
            _timeToFinishSlide = (2 * PlayerData.SlideDistance) / PlayerData.SlideSpeed; //All hail Physics!
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (!IsGrounded)
            {
                StateMachine.ChangeState(PlayerController.InAirState);
                return;
            }

            float targetVelocityX = 0f;
            float xMovement = 0f;
            
            _timer += Time.deltaTime;
            if (_timer >= _timeToFinishSlide)
            {
                targetVelocityX = 0f;
                xMovement = Mathf.SmoothDamp(PlayerController.CurrentVelocity.x, targetVelocityX, ref _velocityXSmoothing, PlayerData.SlideAcceleration);
                PlayerController.AnimController.PlayAnimation(AnimationConstants.PLAYER_STAND_HASH);
            }
            else 
            { 
                targetVelocityX = _slideDirection.x * PlayerData.SlideSpeed; 
                xMovement = Mathf.SmoothDamp(PlayerController.CurrentVelocity.x, targetVelocityX, ref _velocityXSmoothing, PlayerData.SlideAcceleration);
            }
            
            PlayerController.SetVelocityX(xMovement);
        }

        public override void AnimationFinishTrigger()
        {
            base.AnimationFinishTrigger();
            IsAbilityDone = true;
        }

        public override void OnExit()
        {
            base.OnExit();

            PlayerController.CombatController.SetInvencibility(false);
            PlayerController.Collider.direction = CapsuleDirection2D.Vertical;
            PlayerController.Collider.size = PlayerData.NormalColliderSize;
            PlayerController.Collider.offset = PlayerData.NormalColliderOffset;
        }
    }
}
