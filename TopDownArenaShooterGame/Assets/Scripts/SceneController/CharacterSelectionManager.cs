using System;
using Ability;
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
        
        [SerializeField] private TextMeshProUGUI characterNameBack;
        [SerializeField] private TextMeshProUGUI descriptionBack;
        [SerializeField] private TextMeshProUGUI characterStory;

        [SerializeField] private Button button;
        [SerializeField] private GameObject card;
        [SerializeField] private GameObject cardFront;
        [SerializeField] private GameObject cardBack;
        [SerializeField] private StatManager playerStatManager;
        [SerializeField] private AbilityManager abilityManager;
        [SerializeField] private StatsUpgrade baseStat;

        private AbilityHolder _qHolder;
        private AbilityHolder _eHolder;
        private AbilityHolder _spaceHolder;

        private void OnEnable()
        {
            _qHolder = gameObject.AddComponent<AbilityHolder>();
            _qHolder.key = KeyCode.Q;
            _eHolder = gameObject.AddComponent<AbilityHolder>();
            _eHolder.key = KeyCode.E;
            _spaceHolder = gameObject.AddComponent<AbilityHolder>();
            _spaceHolder.key = KeyCode.Space;
        }
        
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
            if (!card.activeInHierarchy)
                card.SetActive(true);
        }

        public void LoadStory(Story story)
        {
            characterStory.text = story.story;
        }

        public void TurnCard()
        {
            if (cardFront.gameObject.activeInHierarchy)
            {
                cardBack.gameObject.SetActive(true);
                cardFront.gameObject.SetActive(false);
            }
            else
            {
                cardBack.gameObject.SetActive(false);
                cardFront.gameObject.SetActive(true);
            }
        }
        
        private void LoadName(string _name)
        {
            characterName.text = _name;
            characterNameBack.text = _name;
        }
        
        private void LoadDescription(string _description)
        {
            description.text = "\"" + _description + "\"";
            descriptionBack.text = "\"" + _description + "\"";
        }

        private void LoadBuff(string type, float value)
        {
            buffs.text += $"+{value} {type}\n";
        }
        
        private void LoadDebuff(string type, float value)
        {
            debuffs.text += $"{value} {type}\n";
        }

        public void LoadQAbility(Ability.Ability q)
        {
            _qHolder.ability = q;
        }
        public void LoadEAbility(Ability.Ability e)
        {
            _eHolder.ability = e;
        }

        public void LoadSpaceAbility(Ability.Ability space)
        {
            _spaceHolder.ability = space;
        }
        
        
        public void Play()
        {
            playerStatManager.AddUpgrade(baseStat);
            playerStatManager.AddUpgrade(_currentStatUpgrade);
            abilityManager.q = _qHolder;
            abilityManager.e = _eHolder;
            abilityManager.space = _spaceHolder;
            SceneManager.LoadScene("GameScene");
        }
    }
}