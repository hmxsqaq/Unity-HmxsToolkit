using Hmxs.Toolkit.Events;
using Hmxs.Toolkit.Quests;
using Hmxs.Toolkit.Quests.MonoClass;
using UnityEngine;
using UnityEngine.Serialization;

namespace Hmxs.Example.Quests
{
    public class CollectCoinsQuestStep : QuestStep
    {
        [SerializeField] private int coinsTargetCount = 5;
        [SerializeField] private int coinsCurrentCount = 0;

        private void OnEnable()
        {
            EventCenter.AddListener(QuestEvents.TestQuestOnCoinCollected, OnCoinCollected);
        }

        private void OnDisable()
        {
            EventCenter.RemoveListener(QuestEvents.TestQuestOnCoinCollected, OnCoinCollected);
        }

        private void OnCoinCollected()
        {
            if (coinsCurrentCount < coinsTargetCount)
            {
                coinsCurrentCount++;
                Debug.Log($"CurrentCoin: {coinsCurrentCount}");
                StepDataUpdate();
            }
            if (coinsCurrentCount >= coinsTargetCount) 
                FinishStep();
        }

        private void StepDataUpdate()
        {
            SaveStepData(coinsCurrentCount.ToString());
        }

        protected override void LoadStepData(string data)
        {
            coinsCurrentCount = int.Parse(data);
            StepDataUpdate();
        }
    }
}