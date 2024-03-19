using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace ZooWorld.Core
{
    public interface IAssetProvider
    {
        UniTask<T> LoadAssetAsync<T>(AssetReference reference) where T : UnityEngine.Object;
        UniTask<T> LoadAssetAsync<T>(AssetReferenceT<T> reference) where T : UnityEngine.Object;
    }
}