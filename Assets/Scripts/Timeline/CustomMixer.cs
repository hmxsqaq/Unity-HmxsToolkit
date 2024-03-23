using UnityEngine;
using UnityEngine.Playables;

namespace Timeline
{
    public class CustomMixer : PlayableBehaviour
    {
        private GameObject _boundObject;

        public override void OnBehaviourPlay(Playable playable, FrameData info)
        {
            Debug.Log("OnMixerPlay");
        }

        public override void OnBehaviourPause(Playable playable, FrameData info)
        {
            Debug.Log("OnMixerPause");
        }

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            // 如果_boundObject为空则尝试获取绑定对象
            _boundObject ??= playerData as GameObject;
            if (_boundObject == null) return;

            var inputCount = playable.GetInputCount();
            for (var i = 0; i < inputCount; i++)
            {
                // 获取融合权重
                var weight = playable.GetInputWeight(i);

                // 获取当前Clip
                var clipPlayable = (ScriptPlayable<CustomBehavior>)playable.GetInput(i);

                // 获取Clip上的Behavior
                var behavior = clipPlayable.GetBehaviour();

                // do something......
            }


            Debug.Log("OnMixerProcessFrame");
        }
    }
}