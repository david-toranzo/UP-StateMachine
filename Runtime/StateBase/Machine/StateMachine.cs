namespace Patterns.StateMachine
{
    public class StateMachine : IStateMachine
    {
        protected IStateBase _currentState = null;

        public void SetCurrentState(IStateBase newState)
        {
            if (_currentState != null)
                _currentState.Exit();

            if (newState == null)
                throw new System.Exception("The current state is null!");

            _currentState = newState;
            _currentState.Enter();
        }

        public void RunStayCurrentState()
        {
            _currentState.Stay();
        }
    }
}