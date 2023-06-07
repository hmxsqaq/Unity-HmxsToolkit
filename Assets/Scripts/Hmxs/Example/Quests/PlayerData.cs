using System;
using UnityEngine;

namespace Hmxs.Example.Quests
{
    public static class PlayerData
    {
        private static int _level = 1;
        public static int Level
        {
            get => _level;
            set
            {
                if (_level == value)
                    return;
                _level = value;
                OnLevelChange?.Invoke();
            }
        }

        public static Action OnLevelChange = () =>
        {
            Debug.Log($"PlayerLevel: {Level}");
        };
    }
}