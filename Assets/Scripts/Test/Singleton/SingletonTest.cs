using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Test.Singleton
{
    public class SingletonTest : MonoBehaviour
    {
        [Button]
        private void LoadNextScene()
        {
            var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1 >= SceneManager.sceneCountInBuildSettings ? 0 : currentSceneIndex + 1);
        }

        [Button]
        private void Test()
        {
            MySingletonMono.Instance.PrintMyValue();
        }
    }
}
