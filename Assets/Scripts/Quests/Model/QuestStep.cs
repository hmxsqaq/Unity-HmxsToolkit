using Hmxs.Toolkit;
using UnityEngine;

namespace Quests
{
    /// <summary>
    /// QuestStep抽象类,每个Step类继承此类,在Step中实现判断逻辑
    /// </summary>
    public abstract class QuestStep : MonoBehaviour
    {
        private bool _isFinished;
        private string _questId;
        private int _stepIndex;

        public void InitStep(string id, int index, string stepData)
        {
            _questId = id;
            _stepIndex = index;
            // if (!string.IsNullOrEmpty(stepData)) 
            //     LoadStepData(stepData);
        }
        
        /// <summary>
        /// 一个Step结束时调用
        /// </summary>
        protected void FinishStep()
        {
            if (_isFinished) return;
            _isFinished = true;
            //Events.Trigger(EventGroups.Quests.QuestAdvance, _questId);
            Destroy(gameObject);
        }

        // protected void SaveStepData(string data)
        // {
        //     Events.Events.Trigger(EventGroups.Quests.QuestStepDataUpdate, _questId, _stepIndex, new QuestStepData(data));
        // }
        //
        // protected abstract void LoadStepData(string data);
    }
}