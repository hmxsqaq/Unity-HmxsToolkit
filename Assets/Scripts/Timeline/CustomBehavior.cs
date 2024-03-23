using UnityEngine;
using UnityEngine.Playables;

namespace Timeline
{
    public class CustomBehavior : PlayableBehaviour
    {
        public override void OnBehaviourPlay(Playable playable, FrameData info)
        {
            Debug.Log("OnBehaviourPlay");
        }

        public override void OnBehaviourPause(Playable playable, FrameData info)
        {
            Debug.Log("OnBehaviourPause");
        }

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            Debug.Log("OnBehaviourProcessFrame");
        }
    }
}