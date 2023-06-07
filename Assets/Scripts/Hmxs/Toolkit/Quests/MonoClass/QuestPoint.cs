using Hmxs.Toolkit.Events;
using Hmxs.Toolkit.Quests.DataClass;
using UnityEngine;

namespace Hmxs.Toolkit.Quests.MonoClass
{
    /// <summary>
    /// 挂载在任务的起点/终点,通过Collider进行检测
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    public class QuestPoint : MonoBehaviour
    {
        [Header("Quest")]
        [SerializeField] private QuestInfoSO questInfo;

        [Header("Config")]
        [SerializeField] private bool isStartPoint = true;
        [SerializeField] private bool isFinishPoint = true;

        private bool _playerIsNear;
        private string _questId;
        private QuestState _currentState;
        private QuestIcon _questIcon;

        private void Awake()
        {
            _questId = questInfo.ID;
            _questIcon = GetComponentInChildren<QuestIcon>();
        }

        private void OnEnable()
        {
            EventCenter.AddListener<Quest>(QuestEvents.QuestStateChange, OnQuestStateChange);
            EventCenter.AddListener(PlayerEvents.SubmitPressed, OnSubmitPressed);
        }

        private void OnDisable()
        {
            EventCenter.RemoveListener<Quest>(QuestEvents.QuestStateChange, OnQuestStateChange);
            EventCenter.RemoveListener(PlayerEvents.SubmitPressed, OnSubmitPressed);
        }
        
        /// <summary>
        /// 更新任务状态,由QuestManager更新
        /// </summary>
        private void OnQuestStateChange(Quest quest)
        {
            if (quest.Info.ID.Equals(_questId))
            {
                _currentState = quest.State;
                _questIcon.SetState(_currentState, isStartPoint, isFinishPoint);
            }
        }

        /// <summary>
        /// 当玩家与任务点交互时
        /// </summary>
        private void OnSubmitPressed()
        {
            if (!_playerIsNear) return;

            switch (_currentState)
            {
                case QuestState.CanStart:
                    if (isStartPoint) 
                        EventCenter.Trigger<string>(QuestEvents.QuestStart, _questId);
                    break;
                case QuestState.CanFinish:
                    if (isFinishPoint) 
                        EventCenter.Trigger<string>(QuestEvents.QuestFinish, _questId);
                    break;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _playerIsNear = true;
            }
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _playerIsNear = false;
            }
        }
    }
}