using Stats;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SceneController
{
    public class CharacterSelectionManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI characterName;
        [SerializeField] private TextMeshProUGUI description;
        [SerializeField] private TextMeshProUGUI buffs;
        [SerializeField] private TextMeshProUGUI debuffs;
        
        [SerializeField] private Button button;
        [SerializeField] private StatManager playerStatManager;
        [SerializeField] private StatsUpgrade baseStat;
        
        
        private StatsUpgrade _currentStatUpgrade;


        public void Load(StatsUpgrade statsUpgrade)
        {
            _currentStatUpgrade = statsUpgrade;
            LoadName(statsUpgrade.name);
            LoadDescription(statsUpgrade.Description);

            buffs.text = "";
            debuffs.text = "";
            foreach (var stat in  statsUpgrade.upgradeToApply)
            {
                
                string type = stat.statType.ToString();
                float value = stat.value;

                if (stat.value > 0) 
                    LoadBuff(type, value);
                else 
                    LoadDebuff(type, value);
            }
            
            if (!button.gameObject.activeInHierarchy)
                button.gameObject.SetActive(true);
            
        }
        
        private void LoadName(string _name)
        {
            characterName.text = _name;
        }
        
        private void LoadDescription(string _description)
        {
            description.text = _description;
        }

        private void LoadBuff(string type, float value)
        {
            buffs.text += $"+{value} {type}\n";
        }
        
        private void LoadDebuff(string type, float value)
        {
            debuffs.text += $"{value} {type}\n";
        }
        
        
        public void Play()
        {
            playerStatManager.AddUpgrade(baseStat);
            playerStatManager.AddUpgrade(_currentStatUpgrade);
            SceneManager.LoadScene("GameScene");
        }
    }
}