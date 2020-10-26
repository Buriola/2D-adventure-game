using System;
using UnityEngine;
using Buriola._2D_Physics;
using Buriola.InputSystem;
using CallbackContext = UnityEngine.InputSystem.InputAction.CallbackContext;

namespace Buriola.Player
{
    [RequireComponent(typeof(Entity2D))]
    [DisallowMultipleComponent]
    public class Player2D : MonoBehaviour
    {
        private Entity2D _entity2D;

        [SerializeField] private float _moveSpeed = 4f;
        
        private float _gravity = -20f;
        private Vector2 _velocity;

        private void OnEnable()
        {
            InputController.Instance.GameInputContext.OnMovementStart += OnMovementStart;
            InputController.Instance.GameInputContext.OnMovementEnded += OnMovementEnded;
        }

        private void Start()
        {
            _entity2D = GetComponent<Entity2D>();
        }

        private void FixedUpdate()
        {
            float delta = Time.fixedDeltaTime;
            
            _velocity.y += _gravity * delta;
            _entity2D.Move(_velocity * delta);
        }

        private void OnMovementStart(CallbackContext obj)
        {
            Vector2 input = obj.ReadValue<Vector2>();
            input.Normalize();
            
            if (input == Vector2.zero) return;
            
            _velocity.x = input.x * _moveSpeed;
        }

        private void OnMovementEnded(CallbackContext obj)
        {
            _velocity.x = 0f;
        }
    }
}
