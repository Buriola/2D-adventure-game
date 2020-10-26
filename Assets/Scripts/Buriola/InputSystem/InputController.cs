namespace Buriola.InputSystem
{
    public sealed class InputController
    {
        private static InputController _instance;
        public static InputController Instance => _instance ?? new InputController();

        private readonly InputAsset _controls;

        public enum EInputContext
        {
            InGame,
            UI,
        }
        private EInputContext _inputContext;
        
        public InGameInputContext GameInputContext { get; }
        public UIInputContext UIInputContext { get; }
        
        public InputController()
        {
            if(_instance != null) return;
            
            _controls = new InputAsset();
            _instance = this;
            _inputContext = EInputContext.InGame;

            GameInputContext = new InGameInputContext(_controls.Game);
            UIInputContext = new UIInputContext(_controls.UI);

            EnablePlayerInput();
        }

        public void EnablePlayerInput()
        {
            SetInputContext(_inputContext);
        }
        
        public void DisablePlayerInput()
        {
            _controls.Game.Disable();
            _controls.UI.Disable();
        }
        
        public void SetInputContext(EInputContext context)
        {
            _inputContext = context;

            switch (_inputContext)
            {
                case EInputContext.InGame:
                    _controls.Game.Enable();
                    _controls.UI.Disable();
                    break;
                case EInputContext.UI:
                    _controls.UI.Enable();
                    _controls.Game.Disable();
                    break;
                default:
                    _controls.Game.Enable();
                    _controls.UI.Disable();
                    break;
            }
        }
    }
}
