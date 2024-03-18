using UnityEngine;
using UnityEngine.AddressableAssets;

namespace ZooWorld.Game
{
    [CreateAssetMenu(fileName = "Assets", menuName = "Game/Assets", order = 1)]
    public class Assets : ScriptableObject
    {
        [SerializeField] private AssetReference frogModel;
        [SerializeField] private AssetReference snakeModel;
    }
}
