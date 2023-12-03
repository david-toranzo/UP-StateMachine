using UnityEngine;

namespace Patterns.StateMachine
{
    public abstract class Transition : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] protected StateBase _nextStateMove;

        public virtual StateBase GetNextStateMove() => _nextStateMove;

        public abstract bool GetProcessTransitionVerification();
    }

}