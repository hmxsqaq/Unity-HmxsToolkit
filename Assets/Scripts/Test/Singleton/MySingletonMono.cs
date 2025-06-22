using Hmxs.Toolkit;
using UnityEngine;

namespace Test.Singleton
{
    public class MySingletonMono : SingletonMono<MySingletonMono>
    {
        private int MyValue { get; set; } = 10;

        protected override bool KeepAliveAcrossScenes => false;

        protected override void Awake()
        {
            base.Awake();
            Debug.Log("MySingletonMono Awake");
        }

        private void Start()
        {
            Debug.Log("MySingletonMono Start");
        }

        public void PrintMyValue()
        {
            Debug.Log($"MyValue: {MyValue}");
            Debug.Log(Instance.gameObject.activeSelf);
        }
    }
}
