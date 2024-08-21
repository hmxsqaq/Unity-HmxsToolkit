using Sirenix.OdinInspector;
using UnityEngine;

namespace Test.Singleton
{
    public class SingletonTest : MonoBehaviour
    {
        [Button]
        private void Test()
        {
            MySingleton.Instance.PrintMyValue();
            MySingletonMono.Instance.PrintMyValue();
            MySingletonScriptableObject.Instance.PrintMyValue();
        }
    }
}