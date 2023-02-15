using System;
using System.Collections;
using Fire;
using Stats;
using UnityEngine;
using Input = UnityEngine.Windows.Input;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private StatManager statManager;
        private PlayerMovement movement; 
        private Rigidbody2D rb2d;

        [SerializeField] private KeyCode key;
        

        private void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
            movement = new PlayerMovement(rb2d);
            StatManager.OnSpeedUpgrade += movement.setSpeed;
            //TODO edit movement.Speed 
            //StartCoroutine(Fire());
        }

        private void FixedUpdate()
        { 
            movement.Move();
        }

        // this event is for trying whether Observer pattern and stat system works well or not.
        private void OnMouseDown()
        {
            Debug.Log("we are here right now");
            StatsUpgrade trying = new StatsUpgrade();
            
            trying.unitsToUpgrade.Add(this.statManager);
            trying.upgradeToApply.Add(new StatData
            {
                statType = StatType.speed,
                value = 10f
            }); 
            
            trying.DoUpgrade();

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