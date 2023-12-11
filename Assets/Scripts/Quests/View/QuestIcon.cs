using UnityEngine;

namespace Quests
{
    public class QuestIcon : MonoBehaviour
    {
        [Header("ICON")]
        [SerializeField] private GameObject requirementNotMetIcon;
        [SerializeField] private GameObject canStartIcon;
        [SerializeField] private GameObject inProgressIcon;
        [SerializeField] private GameObject canFinishIcon;

        public void SetState(QuestState state, bool isStartPoint, bool isFinishPoint)
        {
            requirementNotMetIcon.SetActive(false);
            canStartIcon.SetActive(false);
            inProgressIcon.SetActive(false);
            canFinishIcon.SetActive(false);

            switch (state)
            {
                case QuestState.RequirementsNotMet:
                    if (isStartPoint) requirementNotMetIcon.SetActive(true);
                    break;
                case QuestState.CanStart:
                    if (isStartPoint) canStartIcon.SetActive(true);
                    break;
                case QuestState.InProgress:
                    if (isFinishPoint) inProgressIcon.SetActive(true);
                    break;
                case QuestState.CanFinish:
                    if (isFinishPoint) canFinishIcon.SetActive(true);
                    break;
                case QuestState.Finished:
                    break;
            }
        }
    }
}