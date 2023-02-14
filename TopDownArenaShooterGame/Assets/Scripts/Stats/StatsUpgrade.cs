using System.Collections.Generic;
using UnityEngine;

namespace Stats
{
    public class StatsUpgrade : Upgrade
    {
        [SerializeField]
        public List<StatManager> unitsToUpgrade = new List<StatManager>();
        public List<StatData> upgradeToApply = new List<StatData>();

        public override void DoUpgrade()
        {
            foreach (var unitToUpgrade in unitsToUpgrade)
            {
                unitToUpgrade.AddUpgrade(this);
            }
        }
    }
}