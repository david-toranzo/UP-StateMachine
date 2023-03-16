namespace Patterns.StateMachine
{
    public interface ISetState
    {
        public void SetCurrentState(IStateBase newState);
    }
}