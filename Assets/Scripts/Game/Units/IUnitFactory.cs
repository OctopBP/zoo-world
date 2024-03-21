using Cysharp.Threading.Tasks;
using UnityEngine;
using ZooWorld.Game.Units.Types;

namespace ZooWorld.Game.Units
{
    public interface IUnitFactory
    {
        public UniTask<GameObject> Create(UnitType type);
    }
}