using UnityEngine.AddressableAssets;
using VContainer.Unity;

namespace ZooWorld.Game.Units.Types
{
    [EnumTypeFor(typeof(AssetReference))]
    [EnumTypeFor(typeof(IInstaller))]
    public enum UnitType
    {
        Frog,
        Snake,
    }
}