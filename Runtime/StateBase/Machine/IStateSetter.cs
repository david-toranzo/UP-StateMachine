namespace Patterns.StateMachine
{
    public interface IStateSetter
    {
        public void SetCurrentState(IStateBase newState);
    }
}