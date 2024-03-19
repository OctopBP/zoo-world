using UnityAttributes;
using UnityEngine;

namespace ZooWorld.Game.Units
{
    public partial class UnitView
    {
        [PublicAccessor] private readonly GameObject _gameObject;
        
        public UnitView(GameObject gameObject)
        {
            _gameObject = gameObject;
        }
    }
}