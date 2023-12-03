using System;

namespace Patterns.StateMachine
{
    public class StateEventNotifier : StateBase, IStateEventNotifier
    {
        public Action OnStateEnter { get; set; }
        public Action OnStateExit { get; set; }
        public Action OnStateStay { get; set; }

        public override void Enter() => OnStateEnter?.Invoke();
        public override void Exit() => OnStateExit?.Invoke();
        protected override void ProcessWorkActualState() => OnStateStay?.Invoke();
    }
}