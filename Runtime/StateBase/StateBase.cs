using UnityEngine;

namespace Patterns.StateMachine
{
    public abstract class StateBase : MonoBehaviour, IStateBase
    {
        [Header("References")]
        [SerializeField] protected Transition[] _transitions;

        protected ISetState _setCurrentState;

        public void ConfigureSetState(ISetState newSetState)
        {
            _setCurrentState = newSetState;
        }

        public abstract void Enter();

        public abstract void Exit();

        public virtual void Stay() //fixedupdate
        {
            ProcessWorkActualState();

            ProcessTransition();
        }

        public virtual void ProcessTransition()
        {
            foreach (Transition trans in _transitions)
            {
                if (trans.GetProcessTransitionVerification())
                {
                    _setCurrentState.SetCurrentState(trans.GetNextStateMove());
                    return;
                }
            }
        }

        protected abstract void ProcessWorkActualState();

    }
}