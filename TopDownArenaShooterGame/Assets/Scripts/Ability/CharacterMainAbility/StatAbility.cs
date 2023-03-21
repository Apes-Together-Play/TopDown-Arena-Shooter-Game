using System;
using System.Collections.Generic;
using Stats;
using UnityEngine;

namespace Ability.CharacterMainAbility
{
    [CreateAssetMenu(menuName = "Stat Ability")]
    public class StatAbility: Ability
    {

        public List<StatInfo> statsToUpgrade = new();

        
        public static event Action<StatType, float, UpgradeType> OnStatAbility;
        public override void Active()
        {
            foreach (var statUpgrade in statsToUpgrade)
            {
                OnStatAbility?.Invoke(statUpgrade.statData.statType, statUpgrade.statData.value, statUpgrade.upgradeType);
            }
        }

        public override void DeActive()
        {
            foreach (var statUpgrade in statsToUpgrade)
            {
               if (statUpgrade.upgradeType == UpgradeType.Multiply)
                    OnStatAbility?.Invoke(statUpgrade.statData.statType, 1 / statUpgrade.statData.value, statUpgrade.upgradeType);
               else
                    OnStatAbility?.Invoke(statUpgrade.statData.statType, -1 * statUpgrade.statData.value, statUpgrade.upgradeType);
            }

        }
    }
}