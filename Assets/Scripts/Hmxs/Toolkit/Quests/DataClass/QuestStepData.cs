using System;

namespace Hmxs.Toolkit.Quests.DataClass
{
    // 用于数据持久化
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