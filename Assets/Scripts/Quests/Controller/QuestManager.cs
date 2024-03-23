using System.Collections.Generic;
using System.Linq;
using Hmxs.Toolkit.Module.Events;
using UnityEngine;

namespace Quests
{
    /// <summary>
    /// 所有Quest的管理器,维护一个包含所有Quest的Dictionary,key为QuestID
    /// </summary>
    public class QuestManager : MonoBehaviour
    {
        [Header("Config")]
        // [SerializeField] private bool loadFormFile = true;
        
        private readonly Dictionary<string, Quest> _questMap = new();

        #region Events Subscribe
        private void OnEnable()
        {
            Events.AddListener<string>(EventGroups.Quests.QuestStart, OnQuestStart);
            Events.AddListener<string>(EventGroups.Quests.QuestAdvance, OnQuestAdvance);
            Events.AddListener<string>(EventGroups.Quests.QuestFinish, OnQuestFinish);
            Events.AddListener<string, int, QuestStepData>(EventGroups.Quests.QuestStepDataUpdate, OnStepDataUpdate);
        }

        private void OnDisable()
        {
            Events.RemoveListener<string>(EventGroups.Quests.QuestStart, OnQuestStart);
            Events.RemoveListener<string>(EventGroups.Quests.QuestAdvance, OnQuestAdvance);
            Events.RemoveListener<string>(EventGroups.Quests.QuestFinish, OnQuestFinish);
            Events.RemoveListener<string, int, QuestStepData>(EventGroups.Quests.QuestStepDataUpdate, OnStepDataUpdate);
        }
        #endregion
        
        private void Awake()
        {
            InitQuestMap();
        }

        private void Start()
        {
            // 广播状态变化事件
            foreach (var quest in _questMap.Values)
            {
                if (quest.State == QuestState.InProgress) 
                    quest.InstantiateCurrentStepPrefab(transform);
                Events.Trigger(EventGroups.Quests.QuestStateChange, quest);
            }
            // 开始运行时先检查一次
            CheckAllQuestsRequirements();
        }

        /// <summary>
        /// _questMap初始化: 从Resources/Quest加载所有QuestInfo到_questMap
        /// </summary>
        private void InitQuestMap()
        {
            QuestInfo[] allQuestInfo = Resources.LoadAll<QuestInfo>($"Quests");
            foreach (var questInfo in allQuestInfo)
            {
                if (_questMap.ContainsKey(questInfo.ID))
                    Debug.LogWarning($"QuestManager: Duplicate ID found when creating quest map, ID = {questInfo.ID}");
                _questMap.Add(questInfo.ID, LoadQuest(questInfo));
            }
        }
        
        /// <summary>
        /// 安全检查: 通过ID获取对应Quest,若对应Quest不存在则报错
        /// </summary>
        private Quest GetQuestById(string id)
        {
            Quest quest = _questMap[id];
            if (quest == null) 
                Debug.LogError($"QuestManager: ID not found in quest map, ID = {id}");
            return quest;
        }
        
        /// <summary>
        /// 改变Quest的状态并触发QuestStateChange事件,通知其他模块进行信息更新
        /// </summary>
        private void ChangeQuestState(string id, QuestState state)
        {
            var quest = GetQuestById(id);
            quest.State = state;
            Events.Trigger(EventGroups.Quests.QuestStateChange, quest);
        }
        
        /// <summary>
        /// 当需要追踪的数据改变时（以Level为例）
        /// </summary>
        private void CheckAllQuestsRequirements()
        {
            foreach (var quest in _questMap.Values.Where(
                         quest => quest.State == QuestState.RequirementsNotMet && CheckRequirementsMetState(quest)))
                ChangeQuestState(quest.Info.ID, QuestState.CanStart);
        }
        
        private bool CheckRequirementsMetState(Quest quest)
        {
            var isMet =
                // todo:判断是否完成前置条件的具体逻辑
                true;

                // 判断前置任务是否完成
            foreach (var prerequisiteQuestInfo in quest.Info.questPrerequisites)
                if (GetQuestById(prerequisiteQuestInfo.ID).State != QuestState.Finished)
                    isMet = false;
            return isMet;
        }

        /// <summary>
        /// 任务开始
        /// </summary>
        private void OnQuestStart(string id)
        {
            Quest quest = GetQuestById(id);
            quest.InstantiateCurrentStepPrefab(transform);
            ChangeQuestState(quest.Info.ID, QuestState.InProgress);
        }

        /// <summary>
        /// 任务推进一个Step
        /// </summary>
        private void OnQuestAdvance(string id)
        {
            Quest quest = GetQuestById(id);
            quest.MoveToNextStep();
            if (quest.CurrentStepExists())
                quest.InstantiateCurrentStepPrefab(transform);
            else
                ChangeQuestState(quest.Info.ID, QuestState.CanFinish);
        }

        /// <summary>
        /// 任务结束
        /// </summary>
        private void OnQuestFinish(string id)
        {
            Quest quest = GetQuestById(id);
            GetReward(quest);
            ChangeQuestState(quest.Info.ID, QuestState.Finished);
        }

        /// <summary>
        /// 获得报酬
        /// </summary>
        private void GetReward(Quest quest)
        {
            // todo:获取报酬的逻辑
        }

        private void OnStepDataUpdate(string id, int stepIndex, QuestStepData stepData)
        {
            Quest quest = GetQuestById(id);
            quest.SaveStepData(stepData, stepIndex);
            ChangeQuestState(id, quest.State);
        }

        // private void OnApplicationQuit()
        // {
        //     foreach (var quest in _questMap.Values)
        //     {
        //         QuestData data = quest.GetQuestData();
        //         ES3.Save($"{quest.Info.ID}", data);
        //     }
        // }
        //
        private Quest LoadQuest(QuestInfo info)
        {
            // if (!ES3.KeyExists($"{info.ID}") || !loadFormFile) return new Quest(info);
            // var data = ES3.Load<QuestData>($"{info.ID}");
            // return new Quest(info, data.state, data.stepIndex, data.stepData);
            return new Quest(info);
        }
    }
}