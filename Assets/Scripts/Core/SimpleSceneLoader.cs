using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

namespace ZooWorld.Core
{
    public class SimpleSceneLoader : ISceneLoader
    {
        [Inject] private readonly LifetimeScope _parent;
        
        public void LoadScene(string name, LoadSceneMode mode = LoadSceneMode.Single)
        {
            using (LifetimeScope.EnqueueParent(_parent))
            {
                SceneManager.LoadScene(name, mode);
            }
        }

        public async UniTask LoadSceneAsync(string name, LoadSceneMode mode = LoadSceneMode.Single)
        {
            using (LifetimeScope.EnqueueParent(_parent))
            {
                await SceneManager.LoadSceneAsync(name, mode).ToUniTask();;
            }
        }
    }
}