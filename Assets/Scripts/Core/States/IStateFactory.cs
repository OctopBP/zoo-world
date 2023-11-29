namespace Zooworld.Core.States
{
	public interface IStateFactory
	{
		public TState Create<TState>() where TState : class, IExitableState, new();
	}
}