using System;
using UnityEngine.Serialization;

namespace Stats
{
    [Serializable]
    public record StatData
    {
        public StatType statType;
        public float value;
    }
}