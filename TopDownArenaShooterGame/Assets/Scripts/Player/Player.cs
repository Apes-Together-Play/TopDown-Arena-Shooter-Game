using System;
using System.Collections;
using Fire;
using Stats;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private StatManager statManager;
        private PlayerMovement movement; 
        private Rigidbody2D rb2d;

        private void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
            movement = new PlayerMovement(rb2d);
            //TODO edit movement.Speed 
            StartCoroutine(Fire());
        }

        private void FixedUpdate()
        { 
            movement.Move();
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