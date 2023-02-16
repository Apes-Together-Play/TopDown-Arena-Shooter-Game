using System;
using System.Collections;
using Ability;
using Fire;
using Stats;
using UnityEngine;
using Input = UnityEngine.Windows.Input;

namespace Player
{
    public class Player : MonoBehaviour
    {
        
        // HADI BISMILLAH

        [SerializeField] private Weapon weapon;
        [SerializeField] private PlayerAnimation playerAnimation;
        
        
        
        
        
        
        [SerializeField] private StatManager statManager;
        public PlayerMovement movement; 
        private Rigidbody2D rb2d;

        [SerializeField] private KeyCode key;

        

        
        
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

            //StartCoroutine(Fire());
        }

        private void FixedUpdate()
        { 
            movement.Move();
            weapon.RotateGun();
            playerAnimation.FlipDude();
            weapon.Shoot();
        }

        private IEnumerator Fire()
        {
            //while (true)
            //{
                //Vector2 mousePosition = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
                //var fireData = new FireData();
                //_weapon.Fire(fireData);
                
                // var bulletDirection = mousePosition.normalized;
                // var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                // //bullet.layerMask =  (1<< 8) | (1<<6);
                // bullet.Fire(bulletDirection);
                
                //yield return new WaitForSeconds(0.1f);
            //}
            return null;
        }
    }
}