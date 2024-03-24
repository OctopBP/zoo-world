using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Pool;

namespace ZooWorld.Game.Units.Types
{
    [EnumValuesList]
    [EnumTypeFor(typeof(AssetReference))]
    [EnumTypeFor(typeof(IObjectPool<GameObject>), unitySerializable: false)]
    public enum UnitType
    {
        Frog,
        Snake,
    }
}