namespace Quests
{
    /// <summary>
    /// Quest状态枚举
    /// </summary>
    public enum QuestState
    {
        RequirementsNotMet, // 未完成任务前置条件
        CanStart, // 已完成前置条件，任务可以开始
        InProgress, // 任务进行中
        CanFinish, // 任务可以结束
        Finished // 任务结束
    }
}