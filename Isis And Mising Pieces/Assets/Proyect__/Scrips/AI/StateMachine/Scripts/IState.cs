using System;
using UnityEngine;

namespace MagasLib.StateMachine
{
    public interface IState
    {
        void OnEnter();
        void OnExit();
        void Tick();
        void PhysicsTick();
        void OnAnimationEnterEvent();
        void OnAnimationExitEvent();
        void OnAnimationTransitionEvent();

        void OnTriggerEnterEvent(Collider other);
        void OnTriggerExitEvent(Collider other);

        Type GetStateType()
        {
            return GetType();
        }
    }
}
