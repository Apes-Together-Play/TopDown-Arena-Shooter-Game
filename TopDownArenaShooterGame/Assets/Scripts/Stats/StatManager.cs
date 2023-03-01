using System;
using System.Collections.Generic;
using UnityEngine;

namespace Stats
{
    [Serializable]
    public class StatManager
    {
        public Dictionary<StatType, float> statsInfo = new Dictionary<StatType, float>();
        private readonly List<StatsUpgrade> appliedUpgrades = new();
        
        public static event Action<float> OnSpeedUpgrade;

    
        public void AddUpgrade(StatsUpgrade upgrade)
        {
            Debug.Log("ADDED UPGRADE");
            appliedUpgrades.Add(upgrade);
            
        
            foreach (var statUpgrade in upgrade.upgradeToApply)
            {
                // Adding to the Dictionary 
                statsInfo[statUpgrade.statType] = (statsInfo.TryGetValue(statUpgrade.statType, out float currentValue) ? currentValue : 0) + statUpgrade.value;
                
                
                // OBSERVER PATTERNS....
                if (statUpgrade.statType == StatType.speed)
                    OnSpeedUpgrade?.Invoke(statsInfo[statUpgrade.statType]);
            }
        }
    }
}
