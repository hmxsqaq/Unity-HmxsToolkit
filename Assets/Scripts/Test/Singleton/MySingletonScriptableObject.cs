using Hmxs.Toolkit;
using UnityEngine;

namespace Test.Singleton
{
    [CreateAssetMenu(fileName = "MySingletonScriptableObject", menuName = "Test/Singleton/MySingletonScriptableObject")]
    public class MySingletonScriptableObject : SingletonScriptableObject<MySingletonScriptableObject>
    {
        public int myValue = 10;

        public void PrintMyValue() => Debug.Log($"MyValue: {myValue}");
    }
}