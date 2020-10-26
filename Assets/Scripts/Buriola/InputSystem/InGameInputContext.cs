using System;
using GameActions = Buriola.InputSystem.InputAsset.GameActions;
using CallbackContext = UnityEngine.InputSystem.InputAction.CallbackContext;

namespace Buriola.InputSystem
{
    public sealed class InGameInputContext
    {
        private readonly GameActions _actions;
        
        public InGameInputContext(GameActions gameActions)
        {
            _actions = gameActions;
        }
        
        //WASD and Left Stick
        public event Action<CallbackContext> OnMovementStart
        {
            add => _actions.Movement.performed += value;
            remove => _actions.Movement.performed -= value;
        }
        public event Action<CallbackContext> OnMovementEnded
        {
            add => _actions.Movement.canceled += value;
            remove => _actions.Movement.canceled -= value;
        }
        
        //Mouse movement and Right Stick
        public event Action<CallbackContext> OnLookStart
        {
            add => _actions.Look.performed += value;
            remove => _actions.Look.performed -= value;
        }
        public event Action<CallbackContext> OnLookEnded
        {
            add => _actions.Look.canceled += value;
            remove => _actions.Look.canceled -= value;
        }
        
        //Left trigger and any key you want from the keyboard
        public event Action<CallbackContext> OnLeftTriggerStart
        {
            add => _actions.LeftTrigger.performed += value;
            remove => _actions.LeftTrigger.performed -= value;
        }
        public event Action<CallbackContext> OnLeftTriggerEnded
        {
            add => _actions.LeftTrigger.canceled += value;
            remove => _actions.LeftTrigger.canceled -= value;
        }
        
        //Right trigger and any key you want from the keyboard
        public event Action<CallbackContext> OnRightTriggerStart
        {
            add => _actions.RightTrigger.performed += value;
            remove => _actions.RightTrigger.performed -= value;
        }
        public event Action<CallbackContext> OnRightTriggerEnded
        {
            add => _actions.RightTrigger.canceled += value;
            remove => _actions.RightTrigger.canceled -= value;
        }
        
        //PS4 X or Xbox A from the controller and any key you want from the keyboard
        public event Action<CallbackContext> OnActionButton0Pressed
        {
            add => _actions.ActionButton0.performed += value;
            remove => _actions.ActionButton0.performed -= value;
        }
        public event Action<CallbackContext> OnActionButton0Released
        {
            add => _actions.ActionButton0.canceled += value;
            remove => _actions.ActionButton0.canceled -= value;
        }
        
        //PS4 Circle or Xbox B from the controller and any key you want from the keyboard
        public event Action<CallbackContext> OnActionButton1Pressed
        {
            add => _actions.ActionButton1.performed += value;
            remove => _actions.ActionButton1.performed -= value;
        }
        public event Action<CallbackContext> OnActionButton1Released
        {
            add => _actions.ActionButton1.canceled += value;
            remove => _actions.ActionButton1.canceled -= value;
        }
        
        //PS4 Square or Xbox X from the controller and any key you want from the keyboard
        public event Action<CallbackContext> OnActionButton2Pressed
        {
            add => _actions.ActionButton2.performed += value;
            remove => _actions.ActionButton2.performed -= value;
        }
        public event Action<CallbackContext> OnActionButton2Released
        {
            add => _actions.ActionButton2.canceled += value;
            remove => _actions.ActionButton2.canceled -= value;
        }

        //PS4 triangle or Xbox Y from the controller and any key you want from the keyboard
        public event Action<CallbackContext> OnActionButton3Pressed
        {
            add => _actions.ActionButton3.performed += value;
            remove => _actions.ActionButton3.performed -= value;
        }
        public event Action<CallbackContext> OnActionButton3Released
        {
            add => _actions.ActionButton3.canceled += value;
            remove => _actions.ActionButton3.canceled -= value;
        }
        
        //PS4 R3 or Xbox RS from the controller and any key you want from the keyboard
        public event Action<CallbackContext> OnActionButton4Pressed
        {
            add => _actions.ActionButton4.performed += value;
            remove => _actions.ActionButton4.performed -= value;
        }
        public event Action<CallbackContext> OnActionButton4Released
        {
            add => _actions.ActionButton4.canceled += value;
            remove => _actions.ActionButton4.canceled -= value;
        }
        
        //PS4 L3 or Xbox LS from the controller and any key you want from the keyboard
        public event Action<CallbackContext> OnActionButton5Pressed
        {
            add => _actions.ActionButton5.performed += value;
            remove => _actions.ActionButton5.performed -= value;
        }
        public event Action<CallbackContext> OnActionButton5Released
        {
            add => _actions.ActionButton5.canceled += value;
            remove => _actions.ActionButton5.canceled -= value;
        }
        
        //PS4 L1 or Xbox LB from the controller and any key you want from the keyboard
        public event Action<CallbackContext> OnActionButton6Pressed
        {
            add => _actions.ActionButton6.performed += value;
            remove => _actions.ActionButton6.performed -= value;
        }
        public event Action<CallbackContext> OnActionButton6Released
        {
            add => _actions.ActionButton6.canceled += value;
            remove => _actions.ActionButton6.canceled -= value;
        }

        //PS4 R1 or Xbox RB from the controller and any key you want from the keyboard
        public event Action<CallbackContext> OnActionButton7Pressed
        {
            add => _actions.ActionButton7.performed += value;
            remove => _actions.ActionButton7.performed -= value;
        }
        public event Action<CallbackContext> OnActionButton7Released
        {
            add => _actions.ActionButton7.canceled += value;
            remove => _actions.ActionButton7.canceled -= value;
        }

        //PS4 and Xbox Start from the controller and any key you want from the keyboard
        public event Action<CallbackContext> OnActionButton8Pressed
        {
            add => _actions.ActionButton8.performed += value;
            remove => _actions.ActionButton8.performed -= value;
        }
        public event Action<CallbackContext> OnActionButton8Released
        {
            add => _actions.ActionButton8.canceled += value;
            remove => _actions.ActionButton8.canceled -= value;
        }

        //PS4 Share and Xbox Select from the controller and any key you want from the keyboard
        public event Action<CallbackContext> OnActionButton9Pressed
        {
            add => _actions.ActionButton9.performed += value;
            remove => _actions.ActionButton9.performed -= value;
        }
        public event Action<CallbackContext> OnActionButton9Released
        {
            add => _actions.ActionButton9.canceled += value;
            remove => _actions.ActionButton9.canceled -= value;
        }
        
        //PS4 and Xbox Dpad and keyboard arrows
        public event Action<CallbackContext> OnDpadPressed
        {
            add => _actions.Dpad.performed += value;
            remove => _actions.Dpad.performed -= value;
        }
        public event Action<CallbackContext> OnDpadReleased
        {
            add => _actions.Dpad.canceled += value;
            remove => _actions.Dpad.canceled -= value;
        }
    }
}
