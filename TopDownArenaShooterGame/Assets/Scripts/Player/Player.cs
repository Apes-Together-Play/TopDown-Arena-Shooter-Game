using System;
using System.Collections;
using Ability;
using Fire;
using Stats;
using UnityEngine;

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
                    yield return new WaitForSeconds(0.5f);
                }

                yield return null;
            }
        }
    }
}