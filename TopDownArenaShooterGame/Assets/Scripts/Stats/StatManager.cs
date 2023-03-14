using System;
using System.Collections.Generic;
using Ability;
using UnityEngine;

namespace Stats
{
    [CreateAssetMenu(menuName = "Stat Manager")]
    public class StatManager:ScriptableObject
    {
        private Dictionary<StatType, float> statsInfo;
        private List<StatsUpgrade> appliedUpgrades;

        public event Action<float> OnSpeedUpgrade;
        
        public void OnEnable()
        {
            statsInfo = new Dictionary<StatType, float>();
            appliedUpgrades = new List<StatsUpgrade>();
            DashAbility.OnDashAbility += SetSpeedByMultiply;
        }

        public void AddUpgrade(StatsUpgrade upgrade)
        {
            appliedUpgrades.Add(upgrade);
            foreach (var statUpgrade in upgrade.upgradeToApply)
            {
                // Adding to the Dictionary 
                statsInfo[statUpgrade.statType] = (statsInfo.TryGetValue(statUpgrade.statType, out float currentValue) ? currentValue : 0) + statUpgrade.value;
                
                
                // OBSERVER PATTERNS....
                if (statUpgrade.statType == StatType.speed)
                {
                    OnSpeedUpgrade?.Invoke(statsInfo[statUpgrade.statType]);
                    Debug.Log(OnSpeedUpgrade);
                }
            }
            //Debug.Log(statsInfo[StatType.speed]);
        }
        public void SetSpeedByMultiply(float increaseConstant) => statsInfo[StatType.speed] *= increaseConstant; // 0 olma ihtimalini saap
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
    }
}
