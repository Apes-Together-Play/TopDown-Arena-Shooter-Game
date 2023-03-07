using System;
using System.Collections.Generic;
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

        public float GetStats(StatType type)
        {
            if(statsInfo.TryGetValue(type, out var value))
                return value;

            return 0;
        }
    }
}
