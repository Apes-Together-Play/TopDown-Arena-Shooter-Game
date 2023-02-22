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

        [SerializeField] private Weapon weapon;
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
            weapon.RotateGun();
            playerAnimation.FlipDude();
        }

        
        private IEnumerator Fire()
        {
            while (true)
            {
                if (Input.GetMouseButton(0))
                {
                    weapon.Shoot();
                    float cooldown = 1 / weapon.GetAttackSpeed();

                    float characterAttackSpeedRate = statManager.statsInfo[StatType.attackSpeed];
                    
                    cooldown *= (characterAttackSpeedRate > 0) ? 1 / (1 + characterAttackSpeedRate / 100) : 1 - (characterAttackSpeedRate) / 100; 
                    yield return new WaitForSeconds(cooldown);
                }

                yield return null;
            }
        }
    }
}