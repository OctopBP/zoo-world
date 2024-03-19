using UnityEngine.AddressableAssets;

namespace ZooWorld.Game.Units
{
    [EnumTypeFor(typeof(AssetReference))]
    public enum UnitType
    {
        Frog, 
        Snake,
    }
}