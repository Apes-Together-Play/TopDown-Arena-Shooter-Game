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
        [SerializeField] private List<StatData> stats;
        private Dictionary<StatType, float> statsInfo = new Dictionary<StatType, float>();

        private readonly List<StatsUpgrade> appliedUpgrades = new(); //TODO LIST IS PROBABLY UNNECESSARY
        public static event Action<float> OnSpeedUpgrade; //TODO bunu hallet

    
        public void AddUpgrade(StatsUpgrade upgrade)
        {
            appliedUpgrades.Add(upgrade);
            
        
            foreach (var statUpgrade in upgrade.upgradeToApply)
            {
                // Adding to the Dictionary 
                
                /*
                if (statsInfo.ContainsKey(statUpgrade.statType))
                {
                    statsInfo[statUpgrade.statType] += statUpgrade.value; // if the key exists, add the value to its current value
                }
                else
                {
                    statsInfo[statUpgrade.statType] = statUpgrade.value; // if the key does not exist, create the key with the given value
                }
                */
                
                statsInfo[statUpgrade.statType] = (statsInfo.TryGetValue(statUpgrade.statType, out float currentValue) ? currentValue : 0) + statUpgrade.value;
                
                //
                //// OBSERVER PATTERNS....
                //
                
                if (statUpgrade.statType == StatType.speed)
                    OnSpeedUpgrade?.Invoke(statsInfo[statUpgrade.statType]);
                
                
                
                // Adding to the list
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
            }
        }
    }
}
