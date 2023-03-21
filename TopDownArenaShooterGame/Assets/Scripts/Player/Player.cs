using System;
using System.Collections;
using Ability;
using ObjectPooling.CoinSpawner;
using Stats;
using UnityEngine;
using WeaponManager.Weapon;

namespace Player
{
    public class Player : MonoBehaviour
    {
        // HADI BISMILLAHIRRAHMANIRRAHIM
        
        [SerializeField] private Weapon[] weapons;
        [SerializeField] private PlayerAnimation playerAnimation;
        
        private int _weaponIndex = 0;
        private PlayerMovement movement; 
        private Rigidbody2D rb2d;
        [SerializeField] private  StatManager statManager;
        [SerializeField] private AbilityManager abilityManager;

        

        private void Awake()
        {
            //DontDestroyOnLoad(this);
            //Debug.Log(statManager.statsInfo[StatType.hp]);
            foreach (var weapon in weapons)
            {
               weapon.gameObject.SetActive(false);
            }
        }
        
        private void OnEnable()
        {
            Coin.OnCoinCollectEvent += CollectCoin;
        }

        private void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
            movement = new PlayerMovement(rb2d);
            weapons[_weaponIndex].gameObject.SetActive(true);

            StartCoroutine(Fire());
        }

        private void Update()
        {
            movement.Move(statManager.GetSpeed());
            ChangeWeapon();
            playerAnimation.FlipDude();
            ControlAbilities();
        }

        private void ControlAbilities()
        {
            abilityManager.q.StateTransition();
            abilityManager.e.StateTransition();
            abilityManager.space.StateTransition();
        }
        
        
        private void LateUpdate()
        {
            var currentWeapon = weapons[_weaponIndex];
            currentWeapon.RotateGun();
            currentWeapon.Flip();
        }


        private void ChangeWeapon()
        {
            if (Input.GetKeyDown("1"))
            {
                weapons[_weaponIndex].gameObject.SetActive(false);
                _weaponIndex = 0;
                weapons[_weaponIndex].gameObject.SetActive(true);
            }
            if (Input.GetKeyDown("2"))
            {
                weapons[_weaponIndex].gameObject.SetActive(false);
                _weaponIndex = 1;
                weapons[_weaponIndex].gameObject.SetActive(true);
            }
        }

        
        private IEnumerator Fire()
        {
            while (true)
            {
                if (Input.GetMouseButton(0))
                {
                    var currentWeapon = weapons[_weaponIndex];
                    currentWeapon.Shoot(); 
                    float cooldown = 1 / currentWeapon.AttackSpeed;
                    
                    cooldown *= statManager.GetAttackSpeed(); 
                    yield return new WaitForSeconds(cooldown);
                }

                yield return null;
            }
        }

        public void CollectCoin(Coin coin)
        {
            statManager.SetStat(StatType.money, coin.value);
            Debug.Log(statManager.GetStats(StatType.money));
        }
        
        
    }
}