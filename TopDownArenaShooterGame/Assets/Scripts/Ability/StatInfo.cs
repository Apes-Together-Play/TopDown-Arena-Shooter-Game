using System;
using Stats;

namespace Ability
{
    [Serializable]
    public record StatInfo
    {
        public StatData statData;
        public UpgradeType upgradeType;
    }
}