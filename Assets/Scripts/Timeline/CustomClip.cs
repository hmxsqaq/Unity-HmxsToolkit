using UnityEngine;
using UnityEngine.Playables;

namespace Timeline
{
    public class CustomClip : PlayableAsset
    {
        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            return ScriptPlayable<CustomBehavior>.Create(graph);
        }
    }
}