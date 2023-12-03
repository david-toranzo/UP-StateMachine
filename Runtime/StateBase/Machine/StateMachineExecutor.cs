using System.Collections;
using UnityEngine;

namespace Patterns.StateMachine
{
    public class StateMachineExecutor : MonoBehaviour, IStateSetter
    {
        [SerializeField] private StateBase[] _statesBase;

        protected IStateMachine _stateMachine;

        private WaitForFixedUpdate _waitForFixedUpdate;

        private void OnEnable()
        {
            InitStateMachine();
            InitStates();
            StartFixedCoroutine();
        }

        private void InitStateMachine()
        {
            SetStateMoveMachine(new StateMachine());

            if(_statesBase.Length > 0)
                SetCurrentState(_statesBase[0]);
        }

        private void InitStates()
        {
            foreach (StateBase state in _statesBase)
            {
                state.ConfigureSetState(this);
            }
        }

        public void SetStateMoveMachine(IStateMachine stateMoveMachine)
        {
            _stateMachine = stateMoveMachine;
        }

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