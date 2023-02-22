using System;

namespace Stats
{
    [Serializable]
    public record StatData
    {
        public StatType statType;
        public float value;
    }
}