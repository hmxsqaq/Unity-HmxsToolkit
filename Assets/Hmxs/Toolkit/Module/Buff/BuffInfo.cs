using System;
using UnityEngine;

namespace Hmxs.Toolkit.Module.Buff
{
    [Serializable]
    public class BuffInfo : IComparable<BuffInfo>
    {
        public BuffData buffData;
        public GameObject creator;
        public GameObject target;
        public float durationCounter;
        public float tickCounter;
        public int currentStack = 1;

        public int CompareTo(BuffInfo other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (other == null) return 1;
            if (buffData == null) return other.buffData == null ? 0 : -1;
            if (other.buffData == null) return 1;

            return buffData.id.CompareTo(other.buffData.id);
        }
    }
}