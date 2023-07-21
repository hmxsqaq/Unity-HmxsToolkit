using System;

namespace Hmxs.Toolkit.Module.Quests.Model
{
    /// <summary>
    /// 用于数据持久化
    /// </summary>
    [Serializable]
    public class QuestData
    {
        public QuestState state;
        public int stepIndex;
        public QuestStepData[] stepData;

        public QuestData(QuestState state, int stepIndex, QuestStepData[] stepData)
        {
            this.state = state;
            this.stepIndex = stepIndex;
            this.stepData = stepData;
        }
    }
    
    [Serializable]
    public class QuestStepData
    {
        public string data;

        public QuestStepData(string data)
        {
            this.data = data;
        }

        public QuestStepData()
        {
            data = "";
        }
    }
}