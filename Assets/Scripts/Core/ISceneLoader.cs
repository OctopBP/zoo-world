using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace ZooWorld.Core
{
    public interface ISceneLoader
    {
        void LoadScene(string name, LoadSceneMode mode = LoadSceneMode.Single);
        UniTask LoadSceneAsync(string name, LoadSceneMode mode = LoadSceneMode.Single);
    }
}