using Hmxs.Toolkit.Events;
using UnityEngine;

namespace Hmxs.Example.Events
{
    public class EventListener : MonoBehaviour
    {
        private void Awake()
        {
            EventCenter.AddListener(EventName.TestNoParamEvent, NoParamMethod);
            EventCenter.AddListener<int, string, GameObject>(EventName.Test3ParamEvent, ThreeParamMethod);
        }

        private void OnDestroy()
        {
            EventCenter.AddListener(EventName.TestNoParamEvent, NoParamMethod);
            EventCenter.RemoveListener<int, string, GameObject>(EventName.Test3ParamEvent, ThreeParamMethod);
        }

        private void NoParamMethod()
        {
            Debug.Log("NoParamMethod Triggered");
        }
        
        private void ThreeParamMethod(int number, string names, GameObject obj)
        {
            Debug.Log($"ThreeParamMethod Triggered:{number} {names} {obj.name}");
        }
    }
}