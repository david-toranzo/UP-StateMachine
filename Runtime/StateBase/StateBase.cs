using UnityEngine;

namespace Patterns.StateMachine
{
    public abstract class StateBase : MonoBehaviour, IStateBase
    {
        [Header("References")]
        [SerializeField] protected Transition[] _transitions;

        protected IStateSetter _setCurrentState;

        public void ConfigureSetState(IStateSetter newSetState)
        {
            _setCurrentState = newSetState;
        }

        public abstract void Enter();

        public abstract void Exit();

        public virtual void Stay()
        {
            ProcessWorkActualState();
            ProcessTransition();
        }

        public virtual void ProcessTransition()
        {
            foreach (Transition transition in _transitions)
            {
                if (transition.GetProcessTransitionVerification())
                {
                    _setCurrentState.SetCurrentState(transition.GetNextStateMove());
                    return;
                }
            }
        }

        protected abstract void ProcessWorkActualState();
    }
}