using Hmxs.Toolkit.Events;
using UnityEngine;

namespace Hmxs.Example.Events
{
    public class EventTrigger : MonoBehaviour
    {
        private void Start()
        {
            EventCenter.Trigger(EventName.TestNoParamEvent);
            EventCenter.Trigger<int, string, GameObject>(EventName.Test3ParamEvent, 3, name, gameObject);
        }
    }
}