using System.Collections.Generic;
using UnityEngine;

namespace Stats
{
    public class StatsUpgrade : Upgrade
    {
        [SerializeField]
        public List<StatManager> unitsToUpgrade = new List<StatManager>();
        public Dictionary<Stat, float> upgradeToApply = new Dictionary<Stat, float>();

        public override void DoUpgrade()
        {
            foreach (var unitToUpgrade in unitsToUpgrade)
            {
                unitToUpgrade.AddUpgrade(this); //TODO gelecem sonra
            }
        }
    }
}