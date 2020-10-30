using System;
using UnityEngine;
using Buriola.InputSystem;
using CallbackContext = UnityEngine.InputSystem.InputAction.CallbackContext;

namespace Buriola.Gameplay.Player
{
    public class PlayerInputHandler : MonoBehaviour
    {
        public Vector2 MovementAxis { get; private set; }
        public bool IsJumping { get; private set; }

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
        
        private void OnMovementStart(CallbackContext obj)
        {
            MovementAxis = obj.ReadValue<Vector2>();
            MovementAxis.Normalize();
        }

        private void OnMovementEnded(CallbackContext obj)
        {
            MovementAxis = Vector2.zero;
        }

        private void OnJumpPressed(CallbackContext obj)
        {
            IsJumping = true;
        }

        private void OnJumpEnded(CallbackContext obj)
        {
            IsJumping = false;
        }
    }
}
