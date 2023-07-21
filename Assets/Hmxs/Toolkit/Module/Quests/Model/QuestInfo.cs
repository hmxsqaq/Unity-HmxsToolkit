using UnityEngine;

namespace Hmxs.Toolkit.Module.Quests.Model
{
    /// <summary>
    /// Quest对象数据SO,将QuestInfo创建于Resources/Quests文件夹中,Quest会自动进行读取并实例化对应Quest类
    /// </summary>
    [CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/QuestInfo", order = 1)]
    public class QuestInfo : ScriptableObject
    {
        [field: SerializeField]public string ID { get; private set; }

        [Header("基本信息")]
        public string displayName;

        [Header("前置要求")] 
        public int levelRequirement;
        public QuestInfo[] questPrerequisites;

        [Header("流程")]
        public GameObject[] questStepPrefabs;

        [Header("奖励")] 
        public int experienceReward;
        
        private void OnValidate()
        {
            // 确保ID始终是SO asset名,保证ID的唯一性
#if UNITY_EDITOR
            ID = name;
            UnityEditor.EditorUtility.SetDirty(this);
#endif
        }
    }
}