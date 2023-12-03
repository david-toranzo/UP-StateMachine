using System;

namespace Patterns.StateMachine
{
    public interface IStateEventNotifier
    {
        Action OnStateEnter { get; set; }
        Action OnStateExit { get; set; }
        Action OnStateStay { get; set; }
    }
}