using System;
using System.Security.Cryptography;
using UnityEngine;
using Buriola._2D_Physics;
using Buriola.InputSystem;
using CallbackContext = UnityEngine.InputSystem.InputAction.CallbackContext;

namespace Buriola.Gameplay.Player
{
    [RequireComponent(typeof(Entity2D))]
    [DisallowMultipleComponent]
    public class Player2D : MonoBehaviour
    {
        private Entity2D _entity2D;

        [SerializeField] private float _moveSpeed = 4f;
        [SerializeField] private float _accelerationTimeGrounded = 0.1f;
        [SerializeField] private float _maxClimbAngle = 80f;
        [SerializeField] private float _maxDescendAngle = 75f;
        
        [SerializeField] private float _accelerationTimeAirborne = 0.2f;
        [SerializeField] private float _maxJumpHeight = 8f;
        [SerializeField] private float _minJumpHeight = 1f;
        [SerializeField] private float _timeToJumpApex = 0.4f;
        
        [SerializeField] private float _wallSlideMaxSpeed = 3f;
        [SerializeField] private float _wallStickTime = 0.25f;
        [SerializeField] private Vector2 _wallJumpClimb = Vector2.zero;
        [SerializeField] private Vector2 _wallJumpOff = Vector2.zero;
        [SerializeField] private Vector2 _wallJumpLeap = Vector2.zero;

        private Vector2 _previousVelocity;
        private Vector2 _velocity;
        
        private Vector2 _inputAxis;
        
        private float _gravity;
        private float _maxJumpVelocity;
        private float _minJumpVelocity;
        private float _velocityXSmoothing;
        private float _timeToWallUnstick;
        private float _slopeAngle;
        
        private bool _isWallSliding;
        private int _wallDirectionX;

        private bool _isGrounded;
        private bool _isClimbingSlope;
        private bool _isDescendingSlope;

        private void OnEnable()
        {
            InputController.Instance.GameInputContext.OnMovementStart += OnMovementStart;
            InputController.Instance.GameInputContext.OnMovementEnded += OnMovementEnded;
            InputController.Instance.GameInputContext.OnActionButton0Pressed += OnJumpPressed;
            InputController.Instance.GameInputContext.OnActionButton0Released += OnJumpEnded;
        }

        private void OnDisable()
        {
            InputController.Instance.GameInputContext.OnMovementStart -= OnMovementStart;
            InputController.Instance.GameInputContext.OnMovementEnded -= OnMovementEnded;
            InputController.Instance.GameInputContext.OnActionButton0Pressed -= OnJumpPressed;
            InputController.Instance.GameInputContext.OnActionButton0Released -= OnJumpEnded;
        }

        private void Start()
        {
            _entity2D = GetComponent<Entity2D>();

            _gravity = -(2 * _maxJumpHeight) / Mathf.Pow(_timeToJumpApex, 2);
            _maxJumpVelocity = Mathf.Abs(_gravity) * _timeToJumpApex;
            _minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(_gravity) * _minJumpHeight);
            _timeToWallUnstick = _wallStickTime;
        }

        private void FixedUpdate()
        {
            _wallDirectionX = _entity2D.HasCollisionLeft ? -1 : 1;

            _isGrounded = _entity2D.HasCollisionBelow;
            
            if (_isGrounded)
            {
                _velocity.y = 0f;
            }
            
            Move();
            //ClimbSlope();
            //DescendSlope();
            
            // if (WallSliding())
            // {
            //     HandleWallJumpCooldown();
            // }
            
            _entity2D.Velocity = _velocity * _entity2D.FixedDeltaTime;
            _velocity.y += _gravity * _entity2D.FixedDeltaTime;
        }

        private void OnMovementStart(CallbackContext obj)
        {
            _inputAxis = obj.ReadValue<Vector2>();
            _inputAxis.Normalize();
        }

        private void OnMovementEnded(CallbackContext obj)
        {
            _inputAxis = Vector2.zero;
            _velocity.x = 0f;
        }

        private void OnJumpPressed(CallbackContext obj)
        {
            Jump();
            WallJump();
        }

        private void OnJumpEnded(CallbackContext obj)
        {
            if (_velocity.y > _minJumpHeight)
            {
                _velocity.y = _minJumpVelocity;
            }
        }

        private void Move()
        {
            float targetVelocityX = _inputAxis.x * _moveSpeed;
            _velocity.x = Mathf.SmoothDamp(_velocity.x, targetVelocityX, ref _velocityXSmoothing, _entity2D.HasCollisionBelow ? _accelerationTimeGrounded : _accelerationTimeAirborne);
        }
        
        private void ClimbSlope()
        {
            float moveDistance = Mathf.Abs(_velocity.x);
            float climbVelocityY = Mathf.Sin(_entity2D.SlopeAngle * Mathf.Deg2Rad) * moveDistance;

            // Check if entity is jumping
            if (_velocity.y <= climbVelocityY)
            {
                _velocity.y = climbVelocityY;
                _velocity.x = Mathf.Cos(_entity2D.SlopeAngle * Mathf.Deg2Rad) * moveDistance * Mathf.Sign(_velocity.x);
                
                _slopeAngle = _entity2D.SlopeAngle;
            }
        }
        
        private void DescendSlope()
        {
            float directionX = Mathf.Sign(_velocity.x);
            bool isMovingLeft = directionX == -1;
            
            Vector2 rayOrigin = isMovingLeft ? _entity2D.RayOrigins.BottomRight : _entity2D.RayOrigins.BottomLeft;

            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, Mathf.Infinity, _entity2D.CollisionMask);
            if (hit)
            {
                float slopeAngle = Vector2.Angle(hit.normal, Vector2.up);
                if (slopeAngle != 0 && slopeAngle <= _maxDescendAngle)
                {
                    if (Mathf.Sign(hit.normal.x) == directionX)
                    {
                        if (hit.distance - BaseEntity2D.SKIN_WIDTH <=
                            Mathf.Tan(slopeAngle * Mathf.Deg2Rad) * Mathf.Abs(_velocity.x))
                        {
                            float moveDistance = Mathf.Abs(_velocity.x);
                            float descendVelocityY = Mathf.Sin(slopeAngle * Mathf.Deg2Rad) * moveDistance;

                            _velocity.x = Mathf.Cos(slopeAngle * Mathf.Deg2Rad) * moveDistance *
                                           Mathf.Sign(_velocity.x);

                            _velocity.y -= descendVelocityY;
                            _slopeAngle = slopeAngle;
                        }
                    }
                }
            }
        }
        
        private void Jump()
        {
            if (_entity2D.HasCollisionBelow)
            {
                _velocity.y = _maxJumpVelocity;
            }
        }
        
        private void WallJump()
        {
            if (_isWallSliding)
            {
                if (_wallDirectionX == _inputAxis.x)
                {
                    _velocity.x = -_wallDirectionX * _wallJumpClimb.x;
                    _velocity.y = _wallJumpClimb.y;
                }
                else if (_inputAxis.x == 0f)
                {
                    _velocity.x = -_wallDirectionX * _wallJumpOff.x;
                    _velocity.y = _wallJumpOff.y;
                }
                else
                {
                    _velocity.x = -_wallDirectionX * _wallJumpLeap.x;
                    _velocity.y = _wallJumpLeap.y;
                }
            }
        }
        
        private bool WallSliding()
        {
            _isWallSliding = false;

            bool hasHorizontalCollisions = _entity2D.HasHorizontalCollision;
            bool isFalling = _velocity.y < 0f;
            
            if (hasHorizontalCollisions && !_isGrounded && isFalling)
            {
                _isWallSliding = true;
                if (_velocity.y < -_wallSlideMaxSpeed)
                {
                    _velocity.y = -_wallSlideMaxSpeed;
                }
            }

            return _isWallSliding;
        }
        
        private void HandleWallJumpCooldown()
        {
            if (_timeToWallUnstick > 0)
            {
                _velocity.x = 0f;
                _velocityXSmoothing = 0f;
                    
                if (_inputAxis.x != _wallDirectionX && _inputAxis.x != 0f)
                {
                    _timeToWallUnstick -= _entity2D.FixedDeltaTime;
                }
                else
                {
                    _timeToWallUnstick = _wallStickTime;
                }
            }
            else
            {
                _timeToWallUnstick = _wallStickTime;
            }
        }
    }
}
