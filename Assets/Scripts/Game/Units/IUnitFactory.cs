using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ZooWorld.Game.Units
{
    public interface IUnitFactory
    {
        public UniTask<GameObject> Create(UnitType type);
    }
}