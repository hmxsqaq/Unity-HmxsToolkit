using UnityEngine;

namespace Quests
{
    /// <summary>
    /// 代表一个Quest对象,由Manager依据QuestInfo进行实例化
    /// </summary>
    public class Quest
    {
        public readonly QuestInfo Info; // Quest数据
        public QuestState State; // 当前Quest状态
        
        private int _currentStepIndex; // Info中的Step以GameObject[]的形式存在，通过StepIndex获取对应Step
        private readonly QuestStepData[] _stepData;

        /// <summary>
        /// 通过传入的QuestInfo初始化Quest信息
        /// </summary>
        /// <param name="info"> Quest静态信息 </param>
        public Quest(QuestInfo info)
        {
            Info = info;
            State = QuestState.RequirementsNotMet;
            _currentStepIndex = 0;
            _stepData = new QuestStepData[info.questStepPrefabs.Length];
            for (int i = 0; i < _stepData.Length; i++) 
                _stepData[i] = new QuestStepData();
        }
        
        public Quest(QuestInfo info, QuestState questState, int currentStepIndex, QuestStepData[] stepData)
        {
            Info = info;
            State = questState;
            _currentStepIndex = currentStepIndex;
            _stepData = stepData;
            // 安全检查
            if (_stepData.Length != Info.questStepPrefabs.Length)
            {
                Debug.LogWarning($"Quest: Step Prefabs and Step Data are of different lengths. Check your InfoData QuestId: {Info.ID}");
            }
        }

        /// <summary>
        /// 进行下一个Step
        /// </summary>
        public void MoveToNextStep()
        {
            _currentStepIndex++;
        }

        /// <summary>
        /// 检查当前StepIndex对应的Step是否存在
        /// </summary>
        public bool CurrentStepExists()
        {
            return _currentStepIndex < Info.questStepPrefabs.Length;
        }

        /// <summary>
        /// 实例化当前StepIndex对应的Step的GameObject
        /// </summary>
        /// <param name="parent">创建出的GameObject的父物体</param>
        public void InstantiateCurrentStepPrefab(Transform parent)
        {
            GameObject currentStepPrefab = GetCurrentStepPrefab();
            if (currentStepPrefab != null)
                Object.Instantiate(currentStepPrefab, parent).GetComponent<QuestStep>()
                    .InitStep(Info.ID, _currentStepIndex, _stepData[_currentStepIndex].data);
        }

        /// <summary>
        /// 返回当前StepIndex对应的Step的GameObject
        /// </summary>
        private GameObject GetCurrentStepPrefab()
        {
            GameObject stepPrefab = null;
            if (CurrentStepExists())
                stepPrefab = Info.questStepPrefabs[_currentStepIndex];
            else
                Debug.LogWarning(
                    $"Quest: StepIndex out of range, QuestID = {Info.ID}, StepIndex = {_currentStepIndex}");
            return stepPrefab;
        }

        public void SaveStepData(QuestStepData stepData, int stepIndex)
        {
            if (stepIndex >= _stepData.Length)
                return;
            _stepData[stepIndex].data = stepData.data;
        }

        public QuestData GetQuestData()
        {
            return new QuestData(State, _currentStepIndex, _stepData);
        }
    }
}