using System;
using Stats;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SceneController
{
    public class CharacterSelectionManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMeshProUGUI;
        [SerializeField] private Button button;
        [SerializeField] private StatManager playerStatManager;
        [SerializeField] private StatsUpgrade baseStat;
        
        private StatsUpgrade _currentStatUpgrade;

        public void Load(StatsUpgrade statsUpgrade)
        {
            _currentStatUpgrade = statsUpgrade;
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

        public void Play()
        {
            playerStatManager.AddUpgrade(baseStat);
            playerStatManager.AddUpgrade(_currentStatUpgrade);
            SceneManager.LoadScene("GameScene");
        }
    }
}