namespace Zooworld.Core.States
{
	public interface IPaylodedState<in TPayload> : IExitableState
	{
		void Enter(TPayload payload);
	}
}