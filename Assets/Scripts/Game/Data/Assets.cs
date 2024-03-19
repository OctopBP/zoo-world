using UnityAttributes;
using UnityEngine;

namespace ZooWorld.Game.Data
{
    [CreateAssetMenu(fileName = "Assets", menuName = "Game/Assets", order = 1)]
    public partial class Assets : ScriptableObject
    {
        [SerializeField, PublicAccessor] private Units.UnitTypeForAssetReference _unitModels;
    }
}
