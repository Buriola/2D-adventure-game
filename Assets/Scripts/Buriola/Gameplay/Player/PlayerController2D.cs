﻿using Buriola._2D_Physics;
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

        private Vector2 _globalGroundCheckPoint;
        private Vector2 _previousVelocity;
        private Vector2 _velocity;
        private Vector2 _inputAxis;
        
        private float _gravity;
        private float _maxJumpVelocity;
        private float _minJumpVelocity;
        private float _verticalRaySpacing;
        
        private float _timeToWallUnstick;
        private float _slopeAngle;
        
        private bool _isWallSliding;
        private int _wallDirectionX;

        private bool _isGrounded;
        private bool _isClimbingSlope;
        private bool _isDescendingSlope;

        private void Awake()
        {
            StateMachine = new PlayerStateMachine();
            IdleState = new PlayerIdleState(this, StateMachine, _playerData, AnimationConstants.PLAYER_IDLE);
            MoveState = new PlayerMoveState(this, StateMachine, _playerData, AnimationConstants.PLAYER_MOVING);
            JumpState = new PlayerJumpState(this, StateMachine, _playerData, AnimationConstants.PLAYER_JUMP);
            InAirState = new PlayerInAirState(this, StateMachine, _playerData, AnimationConstants.PLAYER_IN_AIR);
            LandState = new PlayerLandState(this, StateMachine, _playerData, AnimationConstants.PLAYER_LAND);
        }

        private void Start()
        {
            Rb2d = GetComponent<Rigidbody2D>();
            AnimController = GetComponent<AnimationController>();
            InputHandler = GetComponent<PlayerInputHandler>();
            DirectionX = 1;

            _globalGroundCheckPoint = _groundCheckPoint + (Vector2)transform.position;
            
            StateMachine.Initialize(IdleState);
        }

        private void Update()
        {
            CurrentVelocity = Rb2d.velocity;
            StateMachine.CurrentState.OnUpdate();
        }

        private void FixedUpdate()
        {
            StateMachine.CurrentState.OnPhysicsUpdate();
        }

        private void OnDrawGizmosSelected()
        {
            if (_playerData != null)
            {
                Gizmos.color = Color.yellow;
                Vector2 globalWaypointPos = _groundCheckPoint + (Vector2)transform.position;
                Gizmos.DrawWireSphere(globalWaypointPos, _playerData.GroundCheckRadius);
            }
        }
        
        public bool IsGrounded()
        {
            return Physics2D.OverlapCircle(_groundCheckPoint + (Vector2)transform.position, _playerData.GroundCheckRadius, _playerData.CollisionMask);;
        }
        
        private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();
        private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
        
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
        
        private void Flip()
        {
            DirectionX *= -1;
            transform.Rotate(0f, 180f, 0f);
        }
        
        private void ClimbSlope()
        {
            // float moveDistance = Mathf.Abs(_velocity.x);
            // float climbVelocityY = Mathf.Sin(_entity2D.SlopeAngle * Mathf.Deg2Rad) * moveDistance;
            //
            // // Check if entity is jumping
            // if (_velocity.y <= climbVelocityY)
            // {
            //     _velocity.y = climbVelocityY;
            //     _velocity.x = Mathf.Cos(_entity2D.SlopeAngle * Mathf.Deg2Rad) * moveDistance * Mathf.Sign(_velocity.x);
            //     
            //     _slopeAngle = _entity2D.SlopeAngle;
            // }
        }
        
        private void DescendSlope()
        {
            // float directionX = Mathf.Sign(_velocity.x);
            // bool isMovingLeft = directionX == -1;
            //
            // Vector2 rayOrigin = isMovingLeft ? _entity2D.RayOrigins.BottomRight : _entity2D.RayOrigins.BottomLeft;
            //
            // RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, Mathf.Infinity, _entity2D.CollisionMask);
            // if (hit)
            // {
            //     float slopeAngle = Vector2.Angle(hit.normal, Vector2.up);
            //     if (slopeAngle != 0 && slopeAngle <= _maxDescendAngle)
            //     {
            //         if (Mathf.Sign(hit.normal.x) == directionX)
            //         {
            //             if (hit.distance - BaseEntity2D.SKIN_WIDTH <=
            //                 Mathf.Tan(slopeAngle * Mathf.Deg2Rad) * Mathf.Abs(_velocity.x))
            //             {
            //                 float moveDistance = Mathf.Abs(_velocity.x);
            //                 float descendVelocityY = Mathf.Sin(slopeAngle * Mathf.Deg2Rad) * moveDistance;
            //
            //                 _velocity.x = Mathf.Cos(slopeAngle * Mathf.Deg2Rad) * moveDistance *
            //                                Mathf.Sign(_velocity.x);
            //
            //                 _velocity.y -= descendVelocityY;
            //                 _slopeAngle = slopeAngle;
            //             }
            //         }
            //     }
            // }
        }
        
        private void Jump()
        {
            //_rb2d.velocity = new Vector2(_rb2d.velocity.x, _maxJumpVelocity);
        }
        
        private void WallJump()
        {
            // if (_isWallSliding)
            // {
            //     if (_wallDirectionX == _inputAxis.x)
            //     {
            //         _velocity.x = -_wallDirectionX * _wallJumpClimb.x;
            //         _velocity.y = _wallJumpClimb.y;
            //     }
            //     else if (_inputAxis.x == 0f)
            //     {
            //         _velocity.x = -_wallDirectionX * _wallJumpOff.x;
            //         _velocity.y = _wallJumpOff.y;
            //     }
            //     else
            //     {
            //         _velocity.x = -_wallDirectionX * _wallJumpLeap.x;
            //         _velocity.y = _wallJumpLeap.y;
            //     }
            // }
        }
        
        private bool WallSliding()
        {
            // _isWallSliding = false;
            //
            // bool hasHorizontalCollisions = _entity2D.HasHorizontalCollision;
            // bool isFalling = _velocity.y < 0f;
            //
            // if (hasHorizontalCollisions && !_isGrounded && isFalling)
            // {
            //     _isWallSliding = true;
            //     if (_velocity.y < -_wallSlideMaxSpeed)
            //     {
            //         _velocity.y = -_wallSlideMaxSpeed;
            //     }
            // }
            //
            // return _isWallSliding;

            return false;
        }
        
        private void HandleWallJumpCooldown()
        {
            // if (_timeToWallUnstick > 0)
            // {
            //     _velocity.x = 0f;
            //     _velocityXSmoothing = 0f;
            //         
            //     if (_inputAxis.x != _wallDirectionX && _inputAxis.x != 0f)
            //     {
            //         _timeToWallUnstick -= _entity2D.FixedDeltaTime;
            //     }
            //     else
            //     {
            //         _timeToWallUnstick = _wallStickTime;
            //     }
            // }
            // else
            // {
            //     _timeToWallUnstick = _wallStickTime;
            // }
        }
    }
}
