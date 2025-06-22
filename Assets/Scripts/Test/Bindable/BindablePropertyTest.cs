using Hmxs.Toolkit.Core.Bindable;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Test.Bindable
{
    public class BindablePropertyTest : MonoBehaviour
    {
        [SerializeField] private BindableProperty<int> value1;
        [SerializeField] private BindableProperty<int> value2 = new(10);
        [SerializeField] private BindableProperty<int> value3 = new(20, v => Debug.Log($"Value3 changed: {v}"));
        [SerializeField] private BindableProperty<GameObject> value4;

        private void Start()
        {
            value1.onValueChanged.AddListener(v => Debug.Log($"Value1 changed: {v}"));
            value2.onValueChanged.AddListener(v => Debug.Log($"Value2 changed: {v}"));
            value4.onValueChanged.AddListener(v => Debug.Log($"Value4 changed: {v.name}"));
        }

        [Button]
        private void Test()
        {
            value1.Value++;
            value2.Value++;
            value3.Value++;
            value4.Value = gameObject;
        }
    }
}