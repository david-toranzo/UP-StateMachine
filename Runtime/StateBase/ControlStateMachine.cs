using System.Collections;
using UnityEngine;

namespace Patterns.StateMachine
{
    public abstract class ControlStateMachine : MonoBehaviour, ISetState
    {
        protected IStateMachine _stateMachine;

        private WaitForFixedUpdate _waitForFixedUpdate;

        private void OnEnable()
        {
            InitStateMachine();
            InitStates();
            StartFixedCoroutine();
        }
   
        protected abstract void InitStateMachine();

        protected abstract void InitStates();

        protected void StartFixedCoroutine()
        {
            _waitForFixedUpdate = new WaitForFixedUpdate();
            StartCoroutine(FixedUpdateCoroutine());
        }

        private IEnumerator FixedUpdateCoroutine()
        {
            while (true)
            {
                yield return _waitForFixedUpdate;
                _stateMachine.RunStayCurrentState();
            }
        }

        public virtual void SetCurrentState(IStateBase newState)
        {
            _stateMachine.SetCurrentState(newState);
        }

        public void StopStateMachine()
        {
            StopAllCoroutines();
        }

        private void OnDestroy()
        {
            StopStateMachine();
        }
    }
}