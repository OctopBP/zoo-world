using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Zooworld.Core.States
{
    public abstract class StateMachine : IStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _registeredStates = new();
        [CanBeNull] private IExitableState _currentState;

        public void Enter<TState>() where TState : class, IState
        {
            var newState = ChangeState<TState>();
            newState.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPaylodedState<TPayload>
        {
            var newState = ChangeState<TState>(); 
            newState.Enter(payload);
        }

        public void RegisterState<TState>(TState state) where TState : class, IExitableState
        {
            _registeredStates.Add(typeof(TState), state);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _currentState?.Exit();

            var state = GetState<TState>();
            _currentState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState
        {
            return _registeredStates[typeof(TState)] as TState;
        }
    }
}