using UnityEngine;
using ZooWorld.Game.Units.Types;

namespace ZooWorld.Game.Units
{
    public interface IUnitFactory
    {
        public GameObject Get(UnitType type);
    }
}