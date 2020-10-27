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
        [SerializeField] private float _accelerationTimeAirborne = 0.2f;
        [SerializeField] private float _accelerationTimeGrounded = 0.1f;
        [SerializeField] private float _jumpHeight = 8f;
        [SerializeField] private float _timeToJumpApex = 0.4f;
        [SerializeField] private float _wallSlideMaxSpeed = 3f;
        [SerializeField] private float _wallStickTime = 0.25f;
        [SerializeField] private Vector2 _wallJumpClimb = Vector2.zero;
        [SerializeField] private Vector2 _wallJumpOff = Vector2.zero;
        [SerializeField] private Vector2 _wallJumpLeap = Vector2.zero;

        private Vector2 _velocity;
        
        private float _xAxis;
        private float _gravity;
        private float _jumpVelocity;
        private float _velocityXSmoothing;
        private float _timeToWallUnstick;
        
        private bool _isWallSliding;
        private int _wallDirectionX;

        private void OnEnable()
        {
            InputController.Instance.GameInputContext.OnMovementStart += OnMovementStart;
            InputController.Instance.GameInputContext.OnMovementEnded += OnMovementEnded;
            InputController.Instance.GameInputContext.OnActionButton0Pressed += OnJumpPressed;
        }

        private void OnDisable()
        {
            InputController.Instance.GameInputContext.OnMovementStart -= OnMovementStart;
            InputController.Instance.GameInputContext.OnMovementEnded -= OnMovementEnded;
            InputController.Instance.GameInputContext.OnActionButton0Pressed -= OnJumpPressed;
        }

        private void Start()
        {
            _entity2D = GetComponent<Entity2D>();

            _gravity = -(2 * _jumpHeight) / Mathf.Pow(_timeToJumpApex, 2);
            _jumpVelocity = Mathf.Abs(_gravity) * _timeToJumpApex;
            _timeToWallUnstick = _wallStickTime;
        }

        private void Update()
        {
            bool isGrounded = _entity2D.CollisionInfo.IsGrounded;
            
            if (isGrounded)
            {
                _velocity.y = 0f;
            }
        }

        private void FixedUpdate()
        {
            _wallDirectionX = _entity2D.CollisionInfo.Left ? -1 : 1;
            
            float targetVelocityX = _xAxis * _moveSpeed;
            _velocity.x = Mathf.SmoothDamp(_velocity.x, targetVelocityX, ref _velocityXSmoothing, _entity2D.CollisionInfo.IsGrounded ? _accelerationTimeGrounded : _accelerationTimeAirborne);
            
            HandleWallJumpCooldown();
            
            _velocity.y += _gravity * _entity2D.FixedDeltaTime;
            _entity2D.Move(_velocity * _entity2D.FixedDeltaTime);
        }

        private void OnMovementStart(CallbackContext obj)
        {
            Vector2 input = obj.ReadValue<Vector2>();
            input.Normalize();
            
            _xAxis = input.x;
        }

        private void OnMovementEnded(CallbackContext obj)
        {
            _xAxis = 0f;
            _velocity.x = 0f;
        }

        private void OnJumpPressed(CallbackContext obj)
        {
            Jump();
            WallJump();
        }

        private void Jump()
        {
            if (_entity2D.CollisionInfo.IsGrounded)
            {
                _velocity.y = _jumpVelocity;
            }
        }
        
        private void WallJump()
        {
            if (_isWallSliding)
            {
                if (_wallDirectionX == _xAxis)
                {
                    _velocity.x = -_wallDirectionX * _wallJumpClimb.x;
                    _velocity.y = _wallJumpClimb.y;
                }
                else if (_xAxis == 0f)
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
        
        private void HandleWallJumpCooldown()
        {
            _isWallSliding = false;

            bool hasHorizontalCollisions = _entity2D.CollisionInfo.HasHorizontalCollision();
            bool isGrounded = _entity2D.CollisionInfo.IsGrounded;
            bool isFalling = _velocity.y < 0f;
            
            if (hasHorizontalCollisions && !isGrounded && isFalling)
            {
                _isWallSliding = true;
                if (_velocity.y < -_wallSlideMaxSpeed)
                {
                    _velocity.y = -_wallSlideMaxSpeed;
                }
            
                if (_timeToWallUnstick > 0)
                {
                    _velocity.x = 0f;
                    _velocityXSmoothing = 0f;
                    
                    if (_xAxis != _wallDirectionX && _xAxis != 0f)
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
}
