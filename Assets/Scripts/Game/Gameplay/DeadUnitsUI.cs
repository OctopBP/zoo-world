using System;
using UniRx;
using VContainer;
using VContainer.Unity;

namespace ZooWorld.Game.Gameplay
{
    public class DeadUnitsUI : IStartable, IDisposable
    {
        [Inject] private GameUI _gameUI;

        private readonly ReactiveProperty<int> _deadPreysCount = new ReactiveProperty<int>();
        private readonly ReactiveProperty<int> _deadPredatorsCount = new ReactiveProperty<int>();
        
        private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();

        private const string PreysTextFormat = "Dead preys: {0}";
        private const string PredatorsTextFormat = "Dead predators: {0}";
        
        public void Start()
        {
            _deadPreysCount
                .Subscribe(value => _gameUI.DeadPreyCounterText.SetText(string.Format(PreysTextFormat, value)))
                .AddTo(_compositeDisposable);
            
            _deadPredatorsCount
                .Subscribe(value => _gameUI.DeadPredatorsCounterText.SetText(string.Format(PredatorsTextFormat, value)))
                .AddTo(_compositeDisposable);
        }
        
        public void IncreaseDeadPreys()
        {
            _deadPreysCount.Value++;
        }
        
        public void IncreaseDeadPredators()
        {
            _deadPredatorsCount.Value++;
        }

        public void Dispose()
        {
            _compositeDisposable.Dispose();
        }
    }
}