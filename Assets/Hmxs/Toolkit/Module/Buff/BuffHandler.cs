using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Hmxs.Toolkit.Module.Buff
{
    public class BuffHandler : MonoBehaviour
    {
#if UNITY_EDITOR
        [SerializeField] [ReadOnly] private List<BuffInfo> buffList = new();
#endif
        private readonly SortedSet<BuffInfo> _buffSet = new();

        private void Update()
        {
#if UNITY_EDITOR
            buffList = _buffSet.ToList();
#endif
            UpdateBuffTimer();
        }

        private void UpdateBuffTimer()
        {
            foreach (var buffInfo in _buffSet)
            {
                // Update Tick Timer
                if (buffInfo.buffData.tickEvent != null)
                {
                    if (buffInfo.tickCounter < 0)
                    {
                        buffInfo.tickCounter = buffInfo.buffData.tickTime;
                        buffInfo.buffData.tickEvent.OnTick(buffInfo);
                    }
                    else
                        buffInfo.tickCounter -= Time.deltaTime;
                }

                // Update Duration Timer
                if (buffInfo.durationCounter < 0)
                    LostBuff(buffInfo);
                else
                    buffInfo.durationCounter -= Time.deltaTime;
            }
        }

        private BuffInfo GetBuffById(int id) => _buffSet.First(buffInfo => buffInfo.buffData.id == id);

        #region Public Methods

        public void AttachBuff(BuffInfo buffInfo)
        {
            if (_buffSet.Contains(buffInfo))
            {
                // buff存在
                var buff = GetBuffById(buffInfo.buffData.id);
                if (buff.currentStack < buff.buffData.maxStack)
                {
                    // 当前buff层数小于最大层数
                    buff.currentStack++;
                    buff.durationCounter = buff.buffData.attachType switch
                    {
                        BuffAttachType.Add => buff.durationCounter + buff.buffData.durationTime,
                        BuffAttachType.Override => buff.buffData.durationTime,
                        _ => buff.durationCounter
                    };
                }
                else
                {
                    // buff已到最大层数
                    buff.durationCounter = buff.buffData.attachType switch
                    {
                        BuffAttachType.Add => buff.buffData.durationTime * buff.buffData.maxStack,
                        BuffAttachType.Override => buff.buffData.durationTime,
                        _ => buff.durationCounter
                    };
                }
                buff.buffData.baseEvent.OnAttach(buff);
                return;
            }
            // buff不存在
            buffInfo.durationCounter = buffInfo.buffData.durationTime;
            buffInfo.tickCounter = buffInfo.buffData.tickTime;
            buffInfo.buffData.baseEvent.OnAttach(buffInfo);
            _buffSet.Add(buffInfo);
        }

        public void LostBuff(BuffInfo buffInfo)
        {
            switch (buffInfo.buffData.lostType)
            {
                case BuffLostType.Reduce:
                    buffInfo.currentStack--;
                    if (buffInfo.currentStack <= 0)
                    {
                        buffInfo.buffData.baseEvent.OnRemove(buffInfo);
                        _buffSet.Remove(buffInfo);
                    }
                    else
                        buffInfo.durationCounter = buffInfo.buffData.durationTime;
                    break;
                case BuffLostType.Clear:
                    buffInfo.buffData.baseEvent.OnRemove(buffInfo);
                    _buffSet.Remove(buffInfo);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #endregion
    }
}