using Hmxs.Toolkit;

namespace Test.Singleton
{
    public class MySingletonMono : SingletonMono<MySingletonMono>
    {
        public int MyValue { get; set; } = 10;

        protected override void OnInstanceInit(MySingletonMono instance)
        {
            base.OnInstanceInit(instance);
            UnityEngine.Debug.Log("MySingletonMono instance initialized");
        }

        protected override void Awake()
        {
            base.Awake();
            UnityEngine.Debug.Log("MySingletonMono Awake");
        }

        private void Start()
        {
            UnityEngine.Debug.Log("MySingletonMono Start");
        }

        public void PrintMyValue() => UnityEngine.Debug.Log($"MyValue: {MyValue}");
    }
}