using UnityEngine;
using Zenject;
using Zooworld.Core.States;

namespace Zooworld.Game
{
	public class GameBootstrap : MonoBehaviour
	{
		private GameStateMachine _gameStateMachine;
		private StateFactory _stateFactory;
		
		[Inject]
		void Construct(GameStateMachine gameStateMachine, StateFactory stateFactory)
		{
			_gameStateMachine = gameStateMachine;
			_stateFactory = stateFactory;
		}
		
		private void Start()
		{
			DontDestroyOnLoad(this);
			
			_gameStateMachine.RegisterState(_stateFactory.Create<GameLoopState>());
			_gameStateMachine.Enter<GameLoopState>();
		}
	}

	public class GameLoopState : IState 
	{
		public void Exit() { }
		public void Enter() { }
	}
}