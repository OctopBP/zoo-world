using VContainer;
using ZooWorld.Game.Units.Types;
using ZooWorld.Game.Units.Views;

namespace ZooWorld.Game.Units
{
    public class PoolContainer
    {
        [Inject] private UnitView _unitView;
        [Inject] private UnitFactory _unitFactory;
        [Inject] private UnitType _unitType;

        public void Release()
        {
            _unitFactory.Release(_unitType, _unitView.gameObject);
        }
    }
}