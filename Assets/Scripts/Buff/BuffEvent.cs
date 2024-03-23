using UnityEngine;

namespace Buff
{
    public abstract class BuffEvent : ScriptableObject
    {
        public abstract void Trigger(BuffInfo buffInfo);
    }
}