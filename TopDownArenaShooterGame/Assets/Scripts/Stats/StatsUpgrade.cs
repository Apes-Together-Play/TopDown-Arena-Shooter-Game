using System.Collections.Generic;
using UnityEngine;

namespace Stats
{
    [CreateAssetMenu(menuName = "Upgrade")]
    public class StatsUpgrade : Upgrade
    {
        public List<StatData> upgradeToApply;
    }
}