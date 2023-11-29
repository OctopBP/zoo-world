using System;

namespace Zooworld.Core.States
{
	public class StateFactory : IStateFactory
	{
		public TState Create<TState>() where TState : class, IExitableState, new() =>
			(TState) Activator.CreateInstance(typeof(TState), new object[] { });
	}
}