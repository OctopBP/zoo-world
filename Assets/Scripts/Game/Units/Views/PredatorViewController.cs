using System;
using DG.Tweening;
using UnityEngine;
using VContainer;

namespace ZooWorld.Game.Units.Views
{
    public class PredatorViewController : IDisposable
    {
        [Inject] private PredatorView _predatorView;
        
        private Sequence _sequence;
        
        public void ShowText()
        {
            _sequence?.Kill();
            _sequence = DOTween.Sequence();
            
            _predatorView.Text.gameObject.SetActive(true);
            
            _sequence
                .Append(_predatorView.Text.transform.DOScale(Vector3.one, 0.3f))
                .AppendInterval(0.5f)
                .Append(_predatorView.Text.transform.DOScale(Vector3.zero, 0.1f))
                .OnComplete(() => _predatorView.Text.gameObject.SetActive(false));
        }
        
        public void Dispose()
        {
            _sequence?.Kill();
        }
    }
}