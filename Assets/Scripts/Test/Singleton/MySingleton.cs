using Hmxs.Toolkit;
using UnityEngine;

namespace Test.Singleton
{
    public class MySingleton : Singleton<MySingleton>
    {
        public int MyValue { get; set; } = 10;

        protected override void OnInstanceInit(MySingleton instance)
        {
            base.OnInstanceInit(instance);
            Debug.Log("MySingleton instance initialized");
        }

        public void PrintMyValue() => Debug.Log($"MyValue: {MyValue}");
    }
}