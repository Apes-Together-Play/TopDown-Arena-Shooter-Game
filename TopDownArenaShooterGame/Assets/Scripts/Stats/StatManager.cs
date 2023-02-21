using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace Stats
{
    [Serializable]
    public class StatManager
    {
        //[SerializeField] private List<StatData> stats;
        public Dictionary<StatType, float> statsInfo = new Dictionary<StatType, float>();

        
        private readonly List<StatsUpgrade> appliedUpgrades = new();
        
        public static event Action<float> OnSpeedUpgrade;

    
        public void AddUpgrade(StatsUpgrade upgrade)
        {
            appliedUpgrades.Add(upgrade);
            
        
            foreach (var statUpgrade in upgrade.upgradeToApply)
            {
                // Adding to the Dictionary 
                statsInfo[statUpgrade.statType] = (statsInfo.TryGetValue(statUpgrade.statType, out float currentValue) ? currentValue : 0) + statUpgrade.value;
                
                
                // OBSERVER PATTERNS....
                if (statUpgrade.statType == StatType.speed)
                    OnSpeedUpgrade?.Invoke(statsInfo[statUpgrade.statType]);
                
                
                // Adding to the list
                /*
                foreach (var statData in stats.Where(statData => statData.statType == statUpgrade.statType))
                {
                    statData.value += statUpgrade.value;
                    return;
                }

                stats.Add(new StatData
                {
                    statType = statUpgrade.statType,
                    value = statUpgrade.value
                }); 
                */
            }
        }
    }
}
