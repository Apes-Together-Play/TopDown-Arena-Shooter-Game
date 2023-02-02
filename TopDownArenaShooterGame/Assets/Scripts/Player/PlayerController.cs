using System;
using System.Collections;
using System.Collections.Generic;
using Bullet;
using Enemy;
using Fire;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;

        private Weapon _weapon;

        private Rigidbody2D _rb2d;

        private void Start()
        {
            _rb2d = GetComponent<Rigidbody2D>();
            StartCoroutine(Fire());
        }

        private void Update()
        {
            Move();
        }
        
        private void Move()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            var movement = new Vector2(horizontal, vertical);
            _rb2d.velocity = movement * speed;
        }

        private IEnumerator Fire()
        {
            while (true)
            {
                Vector2 mousePosition = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
                var fireData = new FireData();
                _weapon.Fire(fireData);
                
                // var bulletDirection = mousePosition.normalized;
                // var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                // //bullet.layerMask =  (1<< 8) | (1<<6);
                // bullet.Fire(bulletDirection);
                
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}