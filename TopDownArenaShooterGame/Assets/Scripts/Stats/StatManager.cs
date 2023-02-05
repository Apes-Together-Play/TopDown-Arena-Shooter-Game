using System.Collections;
using System.Collections.Generic;
using Stats;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    
    [SerializeField] private Dictionary<Stat, float> stats = new Dictionary<Stat, float>();
    
    private List<StatsUpgrade> appliedUpgrades = new List<StatsUpgrade>();
    
    public void AddUpgrade(StatsUpgrade upgrade)
    {
        appliedUpgrades.Add(upgrade);
        
        foreach (var statUpgrade in upgrade.upgradeToApply)
        {
            stats[statUpgrade.Key] += statUpgrade.Value;
        }
    }
}

public enum Stat
{
    hp,
    hpRegen,
    damage,
    attackSpeed,
    lifeSteal,
    critChange,
    critDamage,
    armor,
    dodge,
    knockback,
    damageReflection,
    speed,
    luck,
    harvesting,
    hpRate,
    hpRegenRate,
    damageRate,
    attackSpeedRate,
    lifeStealRate,
    critChangeRate,
    critDamageRate,
    armorRate,
    dodgeRate,
    knockbackRate,
    damageReflectionRate,
    speedRate,
    luckRate,
    harvestingRate
}