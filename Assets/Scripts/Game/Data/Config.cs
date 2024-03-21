using System;
using UnityAttributes;
using UnityEngine;

namespace ZooWorld.Game.Data
{
    [CreateAssetMenu(fileName = "Config", menuName = "Game/Config", order = 1)]
    public partial class Config : ScriptableObject
    {
        [SerializeField, PublicAccessor] private Vector2 _spawnRange;
        [SerializeField, PublicAccessor] private JumpMovementConfig _jumpMovement;
        [SerializeField, PublicAccessor] private CrowMovementConfig _crowMovementConfig;
    }
    
    [Serializable]
    public partial class JumpMovementConfig
    {
        [SerializeField, PublicAccessor] private float _speed = 1;
        [SerializeField, PublicAccessor] private AnimationCurve _movementCurve;
    }
    
    [Serializable]
    public partial class CrowMovementConfig
    {
        [SerializeField, PublicAccessor] private float _speed = 1;
    }
}
