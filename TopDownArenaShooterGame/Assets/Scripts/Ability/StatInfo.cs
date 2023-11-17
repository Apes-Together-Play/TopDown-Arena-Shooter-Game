using System;
using OldStats;

namespace Ability
{
    [Serializable]
    public record StatInfo
    {
        public StatData statData;
        public UpgradeType upgradeType;
    }
}