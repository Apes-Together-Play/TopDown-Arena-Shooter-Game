using System;

namespace OldStats
{
    [Serializable]
    public record StatData
    {
        public StatType statType;
        public float value;
    }
}