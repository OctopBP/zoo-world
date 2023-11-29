namespace Zooworld.Core
{
	public interface IAssetProvider
	{
		public TAsset LoadByLabel<TAsset>();
	}
}