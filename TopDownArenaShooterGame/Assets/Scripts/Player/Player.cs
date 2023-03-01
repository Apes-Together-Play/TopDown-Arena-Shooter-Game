using System;
using System.Collections;
using Ability;
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
        public static StatManager statManager = new();

        private void Awake()
        {
            //DontDestroyOnLoad(this);
            //Debug.Log(statManager.statsInfo[StatType.hp]);
            foreach (var weapon in weapons)
            {
               weapon.gameObject.SetActive(false);
            }
        }

        private void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
            movement = new PlayerMovement(rb2d);
            weapons[_weaponIndex].gameObject.SetActive(true);

            StatManager.OnSpeedUpgrade += movement.SetSpeed;
            DashAbility.OnDashAbility += movement.SetSpeedByMultiply;

            // will change in the future
            StatsUpgrade baseStats = ScriptableObject.CreateInstance<StatsUpgrade>();
            //baseStats.unitsToUpgrade.Add(this.statManager);
            baseStats.upgradeToApply.Add(new StatData
            {
                statType = StatType.speed,
                value = 11f
            }); 
            
            
            baseStats.upgradeToApply.Add(
                new StatData
                {
                    statType = StatType.attackSpeed,
                    value = 0f
                });
            
            
            baseStats.upgradeToApply.Add(new StatData
            {
                statType = StatType.hp,
                value = 100f
            });
            
            baseStats.DoUpgrade();

            StartCoroutine(Fire());
        }

        private void Update()
        {
            movement.Move();
            ChangeWeapon();
            playerAnimation.FlipDude();
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

                    float characterAttackSpeedRate = statManager.statsInfo[StatType.attackSpeed];
                    
                    cooldown *= (characterAttackSpeedRate > 0) ? 1 / (1 + characterAttackSpeedRate / 100) : 1 - (characterAttackSpeedRate) / 100; 
                    yield return new WaitForSeconds(cooldown);
                }

                yield return null;
            }
        }
        
        
    }
}