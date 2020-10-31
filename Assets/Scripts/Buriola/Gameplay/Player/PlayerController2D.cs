using System;
using Buriola._2D_Physics;
using Buriola.Gameplay.Animations;
using Buriola.Gameplay.Player.Data;
using Buriola.Gameplay.Player.FSM;
using Buriola.Gameplay.Player.FSM.SubStates;
using UnityEngine;

namespace Buriola.Gameplay.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(AnimationController))]
    [RequireComponent(typeof(PlayerInputHandler))]
    [DisallowMultipleComponent]
    public class PlayerController2D : MonoBehaviour
    {
        private RaycastOrigins2D _raycastOrigins;
        private BoxCollider2D _collider;
        [SerializeField] private PlayerData _playerData = null;
        [SerializeField] private Vector2 _groundCheckPoint = Vector2.zero;

        public Rigidbody2D Rb2d { get; private set; }
        public Vector2 CurrentVelocity { get; private set; }
        public PlayerStateMachine StateMachine { get; private set; }
        public AnimationController AnimController { get; private set; }
        public PlayerInputHandler InputHandler { get; private set; }
        public PlayerIdleState IdleState { get; private set; }
        public PlayerMoveState MoveState { get; private set; }
        public PlayerJumpState JumpState { get; private set; }
        public PlayerInAirState InAirState { get; private set; }
        public PlayerLandState LandState { get; private set; }
        
        public int DirectionX { get; private set; }
        private Vector2 _velocity;
        
        public bool CanJump { get; private set; }
        private float _jumpTimer;

        private void Awake()
        {
            StateMachine = new PlayerStateMachine();
            IdleState = new PlayerIdleState(this, StateMachine, _playerData, AnimationConstants.PLAYER_IDLE_HASH);
            MoveState = new PlayerMoveState(this, StateMachine, _playerData, AnimationConstants.PLAYER_MOVING_HASH);
            JumpState = new PlayerJumpState(this, StateMachine, _playerData, AnimationConstants.PLAYER_JUMP_HASH);
            InAirState = new PlayerInAirState(this, StateMachine, _playerData, AnimationConstants.PLAYER_AIR_HASH);
            LandState = new PlayerLandState(this, StateMachine, _playerData, AnimationConstants.PLAYER_LAND_HASH);
        }

        private void Start()
        {
            Rb2d = GetComponent<Rigidbody2D>();
            AnimController = GetComponent<AnimationController>();
            InputHandler = GetComponent<PlayerInputHandler>();
            DirectionX = 1;
            CanJump = true;

            StateMachine.Initialize(IdleState);
        }

        private void Update()
        {
            CurrentVelocity = Rb2d.velocity;
            StateMachine.CurrentState.OnUpdate();
            
            CheckIfCanJump();
        }

        private void FixedUpdate()
        {
            StateMachine.CurrentState.OnPhysicsUpdate();
        }

        private void OnDisable()
        {
            IdleState.Dispose();
            MoveState.Dispose();
            JumpState.Dispose();
            InAirState.Dispose();
            LandState.Dispose();
        }

        private void OnDrawGizmos()
        {
            if (_playerData != null)
            {
                Gizmos.color = Color.yellow;
                Vector2 globalWaypointPos = _groundCheckPoint + (Vector2)transform.position;
                Gizmos.DrawWireSphere(globalWaypointPos, _playerData.GroundCheckRadius);
            }
        }
        
        private void Flip()
        {
            DirectionX *= -1;
            transform.Rotate(0f, 180f, 0f);
        }

        private void CheckIfCanJump()
        {
            if (!CanJump)
            {
                _jumpTimer += Time.deltaTime;
                if (_jumpTimer >= _playerData.JumpCooldown)
                {
                    _jumpTimer = 0f;
                    CanJump = true;
                }
            }
        }
        
        private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();
        private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
        
        public bool IsGrounded()
        {
            return Physics2D.OverlapCircle(_groundCheckPoint + (Vector2)transform.position, _playerData.GroundCheckRadius, _playerData.CollisionMask);;
        }
        
        public void SetVelocity(Vector2 velocity)
        {
            _velocity = velocity;
            Rb2d.velocity = _velocity;
            CurrentVelocity = _velocity;
        }

        public void SetVelocityX(float xVelocity)
        {
            _velocity.Set(xVelocity, CurrentVelocity.y);
            Rb2d.velocity = _velocity;
            CurrentVelocity = _velocity;
        }

        public void SetVelocityY(float yVelocity)
        {
            _velocity.Set(CurrentVelocity.x, yVelocity);
            Rb2d.velocity = _velocity;
            CurrentVelocity = _velocity;
        }

        public void CheckIfShouldFlip(float xInput)
        {
            if (xInput != 0 && xInput != DirectionX)
            {
                Flip();
            }
        }

        public void SetCanJump(bool canJump)
        {
            CanJump = canJump;
        }
    }
}
