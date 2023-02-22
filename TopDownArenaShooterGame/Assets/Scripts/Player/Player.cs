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

        [SerializeField] private Weapon weapon1;
        [SerializeField] private Weapon weapon2;
        private Weapon _currentWeapon;
        
        [SerializeField] private PlayerAnimation playerAnimation;
        [SerializeField] private StatManager statManager;
        
        private PlayerMovement movement; 
        private Rigidbody2D rb2d;
        
        private void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
            movement = new PlayerMovement(rb2d);
            
            StatManager.OnSpeedUpgrade += movement.SetSpeed;
            DashAbility.OnDashAbility += movement.SetSpeedByMultiply;

            // will change in the future
            StatsUpgrade baseStats = ScriptableObject.CreateInstance<StatsUpgrade>();
            baseStats.unitsToUpgrade.Add(this.statManager);
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
            _currentWeapon.RotateGun();
            playerAnimation.FlipDude();
            
            if (Input.GetKeyDown("1"))
            {
                _currentWeapon = weapon1;
            }
            if (Input.GetKeyDown("2"))
            {
                _currentWeapon = weapon2;
            }

        }

        
        private IEnumerator Fire()
        {
            while (true)
            {
                if (Input.GetMouseButton(0))
                {
                    _currentWeapon.Shoot();
                    float cooldown = 1 / _currentWeapon.GetAttackSpeed();

                    float characterAttackSpeedRate = statManager.statsInfo[StatType.attackSpeed];
                    
                    cooldown *= (characterAttackSpeedRate > 0) ? 1 / (1 + characterAttackSpeedRate / 100) : 1 - (characterAttackSpeedRate) / 100; 
                    yield return new WaitForSeconds(cooldown);
                }

                yield return null;
            }
        }
        
        
    }
}