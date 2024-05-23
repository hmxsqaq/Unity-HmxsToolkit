using System;
using Hmxs.Toolkit;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Test
{
    public class Test1 : MonoBehaviour
    {
        public string Name;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
                SceneManager.LoadScene(Name);

            if (Input.GetKeyDown(KeyCode.D))
            {
                Timer.Register(5f, () =>
                {
                    Debug.Log("5s");
                });
            }
        }
    }
}