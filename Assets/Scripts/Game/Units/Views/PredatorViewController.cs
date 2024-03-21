using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using VContainer;

namespace ZooWorld.Game.Units.Views
{
    public class PredatorViewController : IDisposable
    {
        [Inject] private PredatorView _predatorView;

        private CancellationTokenSource _cts = new CancellationTokenSource();
        
        public async UniTask ShowText()
        {
            var token = _cts.Token;
            
            _cts.Cancel();
            _cts = new CancellationTokenSource();
            
            _predatorView.Text.gameObject.SetActive(true);
            
            await _predatorView.Text.transform.DOScale(Vector3.one, 0.3f).WithCancellation(token);
            await UniTask.Delay(1000, cancellationToken: token);
            await _predatorView.Text.transform.DOScale(Vector3.zero, 0.1f).WithCancellation(token);
            
            _predatorView.Text.gameObject.SetActive(false);
        }
        
        public void Dispose()
        {
            _cts.Dispose();
        }
    }
}