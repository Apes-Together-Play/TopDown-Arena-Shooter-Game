using System.Collections.Generic;
using Ability.CharacterMainAbility;
using UnityEngine;

namespace OldStats
{
    [CreateAssetMenu(menuName = "Stat Manager")]
    public class StatManager : ScriptableObject
    {
        private List<StatsUpgrade> _appliedUpgrades;
        private Dictionary<StatType, float> _statsInfo;


        public void OnEnable()
        {
            _statsInfo = new Dictionary<StatType, float>();
            _appliedUpgrades = new List<StatsUpgrade>();


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
            _appliedUpgrades.Add(upgrade);
            foreach (var statUpgrade in upgrade.upgradeToApply)
                // Adding to the Dictionary 
                _statsInfo[statUpgrade.statType] =
                    (_statsInfo.TryGetValue(statUpgrade.statType, out var currentValue) ? currentValue : 0) +
                    statUpgrade.value;
        }

        public float GetSpeed()
        {
            if (_statsInfo.TryGetValue(StatType.Speed, out var speedValue))
            {
                var speedPercentage = _statsInfo.TryGetValue(StatType.SpeedPercentage, out var value) ? value : 0;
                speedValue *= speedPercentage > 0 ? 1 + speedPercentage / 100 : 1 / (1 - speedPercentage / 100);

                return speedValue;
            }

            return 0;
        }

        public float GetAttackSpeed()
        {
            return _statsInfo.TryGetValue(StatType.AttackSpeed, out var characterAttackSpeedRate)
                ? characterAttackSpeedRate > 0
                    ? 1 / (1 + characterAttackSpeedRate / 100)
                    : 1 - characterAttackSpeedRate / 100
                : 1;
        }

        private float GetBaseDamage()
        {
            return _statsInfo.TryGetValue(StatType.Damage, out var characterDamage) 
                ? (characterDamage > 1) 
                    ? characterDamage 
                    : 1 
                : 1;
        }

        private float GetCriticalIncrease()
        {
            return _statsInfo.TryGetValue(StatType.CriticDamage, out var critDamage) 
                ? critDamage > 100 
                    ? critDamage / 100 
                    : 1  
                : 1;
        }

        public float GetDamage()
        {
            bool isCritical = GetStats(StatType.CriticChange) >= Random.Range(1, 100);
            return isCritical ? GetBaseDamage() * GetCriticalIncrease() : GetBaseDamage();
        }

        public float GetStats(StatType statType)
        {
            if (_statsInfo.TryGetValue(statType, out var value)) return value;
            return 0;
        }


        public void SetStatByMultiply(StatType statType, float value)
        {
            if (_statsInfo.TryGetValue(statType, out var val))
                _statsInfo[statType] *= value;
            else _statsInfo[statType] = 0;
        }

        //todo set stat ismi degistir
        public void SetStat(StatType statType, float value)
        {
            if (_statsInfo.TryGetValue(statType, out var val))
                _statsInfo[statType] += value;
            else _statsInfo[statType] = value;
        }
    }
}