using UnityAttributes;
using UnityEngine;

namespace ZooWorld.Game.Gameplay
{
    public partial class UnitsSpawnerView : MonoBehaviour
    {
        [SerializeField, PublicAccessor] private Transform[] _spawnPoints;
    }
}