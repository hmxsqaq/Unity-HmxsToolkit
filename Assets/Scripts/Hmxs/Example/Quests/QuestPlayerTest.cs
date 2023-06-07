using System;
using Hmxs.Toolkit.Events;
using UnityEngine;

namespace Hmxs.Example.Quests
{
    public class QuestPlayerTest : MonoBehaviour
    {
        private void Awake()
        {
            if (ES3.KeyExists("PlayerLevel"))
            {
                PlayerData.Level = ES3.Load<int>("PlayerLevel");
            }
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                PlayerData.Level += 1;
            }

            if (Input.GetMouseButtonDown(1))
            {
                EventCenter.Trigger(QuestEvents.TestQuestOnCoinCollected);
            }
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                EventCenter.Trigger(PlayerEvents.SubmitPressed);
            }

            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            transform.Translate(new Vector3(horizontalInput,verticalInput) * Time.deltaTime);
        }

        private void OnApplicationQuit()
        {
            ES3.Save("PlayerLevel", PlayerData.Level);
        }
    }
}