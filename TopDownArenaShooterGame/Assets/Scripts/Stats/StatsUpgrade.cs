using System.Collections.Generic;
using UnityEngine;

namespace Stats
{
    [CreateAssetMenu(menuName = "Upgrade")]
    public class StatsUpgrade : Upgrade
    {
        public List<StatData> upgradeToApply = new();

        public override void DoUpgrade(Player.Player playera)
        {
            //var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player.Player>();
            Debug.Log("Add upgrade");
            Player.Player.statManager.AddUpgrade(this);
        }
    }
}