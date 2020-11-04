using UnityEngine;
using Buriola.InputSystem;
using CallbackContext = UnityEngine.InputSystem.InputAction.CallbackContext;

namespace Buriola.Gameplay.Player
{
    [DisallowMultipleComponent]
    public class PlayerInputHandler : MonoBehaviour
    {
        public Vector2 MovementAxis { get; private set; }
        public float RawInputX { get; private set; }
        public float RawInputY { get; private set; }
        public bool JumpInput { get; private set; }
        public bool AttackInput { get; private set; }

        private void OnEnable()
        {
            InputController.Instance.GameInputContext.OnMovementStart += OnMovementStart;
            InputController.Instance.GameInputContext.OnMovementEnded += OnMovementEnded;
            InputController.Instance.GameInputContext.OnActionButton0Pressed += OnJumpPressed;
            InputController.Instance.GameInputContext.OnActionButton0Released += OnJumpEnded;
            InputController.Instance.GameInputContext.OnActionButton2Pressed += OnAttackPressed;
            InputController.Instance.GameInputContext.OnActionButton2Released += OnAttackReleased;
        }

        private void OnDisable()
        {
            InputController.Instance.GameInputContext.OnMovementStart -= OnMovementStart;
            InputController.Instance.GameInputContext.OnMovementEnded -= OnMovementEnded;
            InputController.Instance.GameInputContext.OnActionButton0Pressed -= OnJumpPressed;
            InputController.Instance.GameInputContext.OnActionButton0Released -= OnJumpEnded;
            InputController.Instance.GameInputContext.OnActionButton2Pressed -= OnAttackPressed;
            InputController.Instance.GameInputContext.OnActionButton2Released -= OnAttackReleased;
        }
        
        private void OnMovementStart(CallbackContext obj)
        {
            MovementAxis = obj.ReadValue<Vector2>();

            RawInputX = (MovementAxis.x * Vector2.right).normalized.x;
            RawInputY = (MovementAxis.y * Vector2.up).normalized.y;
        }

        private void OnMovementEnded(CallbackContext obj)
        {
            MovementAxis = Vector2.zero;
            RawInputX = 0f;
            RawInputY = 0f;
        }

        private void OnJumpPressed(CallbackContext obj)
        {
            JumpInput = true;
        }

        private void OnJumpEnded(CallbackContext obj)
        {
            JumpInput = false;
        }

        private void OnAttackPressed(CallbackContext obj)
        {
            AttackInput = true;
        }

        private void OnAttackReleased(CallbackContext obj)
        {
            AttackInput = false;
        }
    }
}
