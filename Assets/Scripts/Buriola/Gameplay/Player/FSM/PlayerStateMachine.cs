namespace Buriola.Gameplay.Player.FSM
{
    public sealed class PlayerStateMachine
    {
        public PlayerState CurrentState { get; private set; }
        public PlayerState PreviousState { get; private set; }

        public void Initialize(PlayerState startingState)
        {
            CurrentState = startingState;
            CurrentState.OnEnter();
        }

        public void ChangeState(PlayerState newState)
        {
            PreviousState = CurrentState;
            CurrentState.OnExit();

            CurrentState = newState;
            CurrentState.OnEnter();
        }
    }
}
