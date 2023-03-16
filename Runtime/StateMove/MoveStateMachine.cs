namespace Patterns.StateMachine
{
    public class MoveStateMachine : StateMachine
    {
        private IStateMoveBase[] _stateBases;

        public MoveStateMachine(IStateMoveBase[] states)
        {
            _stateBases = states;
        }
    }
}
