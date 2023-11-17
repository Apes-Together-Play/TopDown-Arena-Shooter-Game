using System.Collections.Generic;
using UnityEngine;

namespace OldStats
{
    [CreateAssetMenu(menuName = "Upgrade")]
    public class StatsUpgrade : Upgrade
    {
        public List<StatData> upgradeToApply;
    }
}