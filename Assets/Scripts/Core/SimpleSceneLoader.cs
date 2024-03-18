using UnityEngine.SceneManagement;

namespace ZooWorld.Core
{
    public class SimpleSceneLoader : ISceneLoader
    {
        public void LoadScene(string name)
        {
            SceneManager.LoadScene(name);
        }
    }
}