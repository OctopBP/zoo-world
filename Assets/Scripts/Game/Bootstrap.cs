using UnityEngine;
using VContainer;
using ZooWorld.Core;

namespace ZooWorld.Game
{
    public class Bootstrap : MonoBehaviour
    {
        [Inject] private ISceneLoader _sceneLoader;
        [Inject] private ILog _log;
        
        private void Start()
        {
            _log.Log("Bootstrap start");
            _sceneLoader.LoadScene("Game");
        }
    }
}
