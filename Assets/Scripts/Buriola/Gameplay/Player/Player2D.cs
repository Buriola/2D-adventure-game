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
        
        private float _gravity;
        private float _jumpVelocity;

        private Vector2 _velocity;
        private float _velocityXSmoothing;

        private float _xAxis;
        private bool _isJumping;

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

            _gravity = -(2 * _jumpHeight) / Mathf.Pow(_timeToJumpApex, 2);
            _jumpVelocity = Mathf.Abs(_gravity) * _timeToJumpApex;
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
            _velocity.y += _gravity * _entity2D.FixedDeltaTime;
            
            float targetVelocityX = _xAxis * _moveSpeed;
            _velocity.x = Mathf.SmoothDamp(_velocity.x, targetVelocityX, ref _velocityXSmoothing, _entity2D.CollisionInfo.IsGrounded ? _accelerationTimeGrounded : _accelerationTimeAirborne);
            
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
            if (_isJumping || !_entity2D.CollisionInfo.IsGrounded) return;
            
            _isJumping = true;
            _velocity.y = _jumpVelocity;
        }

        private void OnJumpEnded(CallbackContext obj)
        {
            _isJumping = false;
        }
    }
}
