using System;
using Stats;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SceneController
{
    public class CharacterSelection : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMeshProUGUI;
        [SerializeField] private Button button;
        
        public void Load(StatsUpgrade statsUpgrade)
        {
           // TODO edit textMesh pro add some grid
            textMeshProUGUI.text = statsUpgrade.name + "\n" + 
                                   statsUpgrade.Description + "\n" ;
            foreach (var stat in  statsUpgrade.upgradeToApply)
            {
                var value = stat.value;
                var type = stat.statType.ToString();
                textMeshProUGUI.text += stat.value > 0 ? $"+{value} {type}\n" : $"-{value} {type}\n";
            }

            if (!button.gameObject.activeInHierarchy)
            {
                button.gameObject.SetActive(true);
            }
        }
    }
}