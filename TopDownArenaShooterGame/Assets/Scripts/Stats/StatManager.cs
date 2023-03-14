using System;
using System.Collections.Generic;
using Ability;
using Ability.CharacterMainAbility;
using UnityEngine;

namespace Stats
{
    [CreateAssetMenu(menuName = "Stat Manager")]
    public class StatManager:ScriptableObject
    {
        private Dictionary<StatType, float> statsInfo;
        private List<StatsUpgrade> appliedUpgrades;

        
        public void OnEnable()
        {
            statsInfo = new Dictionary<StatType, float>();
            appliedUpgrades = new List<StatsUpgrade>();
            
            
            StatAbility.OnStatAbility += SetStatHelper;
        }

        private void SetStatHelper(StatType statType, float value, UpgradeType upgradeType)
        {
            if (upgradeType == UpgradeType.Multiply)
                SetStatByMultiply(statType, value);
            else 
                SetStat(statType, value);
        }

        public void AddUpgrade(StatsUpgrade upgrade)
        {
            appliedUpgrades.Add(upgrade);
            foreach (var statUpgrade in upgrade.upgradeToApply)
            {
                // Adding to the Dictionary 
                statsInfo[statUpgrade.statType] = (statsInfo.TryGetValue(statUpgrade.statType, out float currentValue) ? currentValue : 0) + statUpgrade.value;
            }
        }
        public float GetSpeed()
        {
            if (statsInfo.TryGetValue(StatType.speed, out var speedValue))
            {
                float speedPercentage = (statsInfo.TryGetValue(StatType.speedPercentage, out var value)) ? value : 0;
                speedValue *= (speedPercentage > 0) ? (1 + speedPercentage / 100) :  1 / (1 - speedPercentage / 100); 
                
                return speedValue;
            }
            return 0;
        }
        public float GetAttackSpeed()
        {
            return statsInfo.TryGetValue(StatType.attackSpeed, out var characterAttackSpeedRate)
                ? (characterAttackSpeedRate > 0)
                    ? 1 / (1 + characterAttackSpeedRate / 100)
                    : 1 - (characterAttackSpeedRate) / 100
                : 1;
        }


        public void SetStatByMultiply(StatType statType, float value)
        {
            if (statsInfo.TryGetValue(statType, out var val))
                statsInfo[statType] *= value;
            else statsInfo[statType] = 0;
        }

        public void SetStat(StatType statType, float value)
        {
            if (statsInfo.TryGetValue(statType, out var val))
                statsInfo[statType] += value;
            else statsInfo[statType] = value;
        }
    }
}
