using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Timeline
{
    [TrackColor(0.5f, 0.5f, 0.5f)]  // Track颜色
    [TrackClipType(typeof(CustomClip))]     // Track上的Clip类型
    [TrackBindingType(typeof(GameObject))]  // Track上的绑定对象类型
    public class CustomTrack : TrackAsset
    {
        // inputCount即为Track上的Clip数量
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            return ScriptPlayable<CustomMixer>.Create(graph, inputCount);
        }
    }
}