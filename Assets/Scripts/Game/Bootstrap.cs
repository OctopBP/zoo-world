using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;
using ZooWorld.Core;

namespace ZooWorld.Game
{
    public class Bootstrap : IAsyncStartable
    {
        [Inject] private readonly ISceneLoader _sceneLoader;
        [Inject] private readonly ILog _log;
        [Inject] private readonly LifetimeScope _parent;
        
        public async UniTask StartAsync(CancellationToken cancellation)
        {
            _log.Log("Bootstrap start");
            await _sceneLoader.LoadSceneAsync("Game", LoadSceneMode.Additive);
        }
    }
}
