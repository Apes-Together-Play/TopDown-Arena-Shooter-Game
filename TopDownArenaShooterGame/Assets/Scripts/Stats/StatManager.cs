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

        private readonly List<StatsUpgrade> appliedUpgrades = new();
    
        public void AddUpgrade(StatsUpgrade upgrade)
        {
            appliedUpgrades.Add(upgrade);
        
            foreach (var statUpgrade in upgrade.upgradeToApply)
            {
                foreach (var statData in stats.Where(statData => statData.statType == statUpgrade.statType))
                {
                    statData.value += statUpgrade.value; // TODO can be negative 
                    return;
                }

                stats.Add(new StatData
                {
                    statType = statUpgrade.statType,
                    value = statUpgrade.value // TODO can be negative 
                }); 
            }
        }
    }
}
