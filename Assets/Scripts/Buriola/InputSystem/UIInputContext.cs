using CallbackContext = UnityEngine.InputSystem.InputAction.CallbackContext;
using UIActions = Buriola.InputSystem.InputAsset.UIActions;
using System;

namespace Buriola.InputSystem
{
    public sealed class UIInputContext
    {
        private UIActions _actions;

        public UIInputContext(UIActions uiActions)
        {
            _actions = uiActions;
        }

        public event Action<CallbackContext> OnConfirmActionPressed
        {
            add => _actions.ConfirmAction.performed += value;
            remove => _actions.ConfirmAction.performed -= value;
        }
        public event Action<CallbackContext> OnConfirmActionReleased
        {
            add => _actions.ConfirmAction.canceled += value;
            remove => _actions.ConfirmAction.canceled -= value;
        }
        
        public event Action<CallbackContext> OnCancelActionPressed
        {
            add => _actions.CancelAction.performed += value;
            remove => _actions.CancelAction.performed -= value;
        }
        public event Action<CallbackContext> OnCancelActionReleased
        {
            add => _actions.CancelAction.canceled += value;
            remove => _actions.CancelAction.canceled -= value;
        }
        
        public event Action<CallbackContext> OnNavigateActionStarted
        {
            add => _actions.NavigateAction.performed += value;
            remove => _actions.NavigateAction.performed -= value;
        }
        public event Action<CallbackContext> OnNavigateActionEnded
        {
            add => _actions.NavigateAction.canceled += value;
            remove => _actions.NavigateAction.canceled -= value;
        }
        
        public event Action<CallbackContext> OnAuxAction0Pressed
        {
            add => _actions.AuxAction0.performed += value;
            remove => _actions.AuxAction0.performed -= value;
        }
        public event Action<CallbackContext> OnAuxAction0Released
        {
            add => _actions.AuxAction0.canceled += value;
            remove => _actions.AuxAction0.canceled -= value;
        }
        
        public event Action<CallbackContext> OnAuxAction1Pressed
        {
            add => _actions.AuxAction1.performed += value;
            remove => _actions.AuxAction1.performed -= value;
        }
        public event Action<CallbackContext> OnAuxAction1Released
        {
            add => _actions.AuxAction1.canceled += value;
            remove => _actions.AuxAction1.canceled -= value;
        }
    }
}
