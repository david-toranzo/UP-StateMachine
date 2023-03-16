using UnityEngine;

namespace Patterns.StateMachine
{
    public class ControlMoveStateMachine : ControlStateMachine
    {
        [Header("References")]
        [SerializeField] private StateBaseMove[] _stateBaseMoves;

        protected override void InitStateMachine()
        {
            var stateMachineMove = new MoveStateMachine(_stateBaseMoves);
            SetStateMoveMachine(stateMachineMove);

            SetCurrentState(_stateBaseMoves[0]);
        }

        protected override void InitStates()
        {
            foreach (StateBaseMove state in _stateBaseMoves)
            {
                state.ConfigureSetState(this);
            }
        }

        public void SetStateMoveMachine(IStateMachine stateMoveMachine)
        {
            _stateMachine = stateMoveMachine;
        }
    }
}
