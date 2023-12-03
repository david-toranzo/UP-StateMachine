namespace Patterns.StateMachine
{
    public interface IStateMachine
    {
        public void SetCurrentState(IStateBase newState);

        public void RunStayCurrentState();
    }
}