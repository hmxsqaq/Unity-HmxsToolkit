using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Test
{
    public class Test1 : MonoBehaviour
    {
        private ObjectPool<GameObject> _pool;
        private readonly List<GameObject> _list = new();

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _pool ??= new ObjectPool<GameObject>(CreateFunc, GetFunc, ReleaseFunc, DestroyFunc,
                    defaultCapacity: 0, maxSize: 10);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                _list.Add(_pool.Get());
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                if (_list.Count > 0)
                {
                    _pool.Release(_list[0]);
                    _list.Remove(_list[0]);
                }
            }
        }

        private GameObject CreateFunc()
        {
            var obj = new GameObject("PoolTest");
            obj.transform.SetParent(transform);
            return obj;
        }

        private void GetFunc(GameObject obj) => obj.SetActive(true);

        private void ReleaseFunc(GameObject obj) => obj.SetActive(false);

        private void DestroyFunc(GameObject obj) => Destroy(obj);
    }
}