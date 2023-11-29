namespace Zooworld.Core
{
	public class StaticDataService : IStaticDataService
	{
		private readonly ILogService _log;
		private readonly IAssetProvider _assetProvider;
		
		// public void Frog _frog;
		// public void Snake _snake;

		public StaticDataService(ILogService log, IAssetProvider assetProvider)
		{
			_log = log;
			_assetProvider = assetProvider;
		}

		public void Init()
		{
			// _frog = _assetProvider.LoadByLabel<Frog>();
			// _snake = _assetProvider.LoadByLabel<Snake>();
		}
	}
}