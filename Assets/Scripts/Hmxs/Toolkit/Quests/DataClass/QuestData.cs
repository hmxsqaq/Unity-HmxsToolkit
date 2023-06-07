using System;

namespace Hmxs.Toolkit.Quests.DataClass
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
}